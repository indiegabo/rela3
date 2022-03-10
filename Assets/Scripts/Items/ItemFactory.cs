using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3.Transitions;
using UnityEngine;
namespace IndieGabo.Rela3.Items
{
    public class ItemFactory : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] [Range(0.01f, 0.1f)] private float _populateSpawnDelay = 0.05f;

        // Needed components
        private ItemProvider _itemProvider;

        // Logic 
        private Board _currentBoard;

        private List<ItemType> blockedTypes = new List<ItemType>();

        private void Awake()
        {
            this._itemProvider = this.GetComponent<ItemProvider>();
        }

        public void Initialize()
        {
            this._itemProvider.Initialize();
        }

        public void PopulateBoard(Board board)
        {
            StartCoroutine(this.FirstSpawn(board));
        }

        private IEnumerator FirstSpawn(Board board)
        {
            this._currentBoard = board;
            for (int y = 0; y < board.rows; y++)
            {
                for (int x = 0; x < board.rows; x++)
                {
                    this.FirstSpawnRandomItem(board.GetTile(new Vector2(x, y)));
                    yield return new WaitForSeconds(this._populateSpawnDelay);
                }
            }
            this._currentBoard = null;
        }

        public void FirstSpawnRandomItem(Tile tile)
        {
            if (this._currentBoard == null) return;

            Vector3 startingPos = new Vector3(
                tile.position.x,
                tile.position.y + this._currentBoard.firstSpawnYDistanceFactor,
                this._currentBoard.transform.position.z - this._currentBoard.itemZDistanceFactor
            );

            this.CheckRepeatingTiles(tile, 1, 0);
            this.CheckRepeatingTiles(tile, 0, 1);

            InstantiableItem instatiableItem = this._itemProvider.GetRandomItem(blockedTypes);

            Item item = Instantiate(instatiableItem.itemPrefab, startingPos, Quaternion.identity, tile.obj.transform);
            tile.item = item;

            ITransition itemTransition = item.GetComponent<ITransition>();
            itemTransition.TransitionTo(tile);

            blockedTypes.Clear();
        }

        private Item CheckRepeatingTiles(Tile currentTile, int horizontal, int vertical)
        {
            Tile tileMinus1 = this._currentBoard.GetTile(new Vector2(currentTile.position.x - 1 * horizontal, currentTile.position.y - 1 * vertical));
            Tile tileMinus2 = this._currentBoard.GetTile(new Vector2(currentTile.position.x - 2 * horizontal, currentTile.position.y - 2 * vertical));

            if (tileMinus1 != null && tileMinus2 != null && tileMinus1.item != null && tileMinus2.item != null)
            {
                blockedTypes.Add(tileMinus1.item.type);
                return tileMinus1.item;
            }
            return null;
        }

        public void SpawnRandomItemOnBoard(Tile tile, Board board)
        {

            Vector3 spawnPos = new Vector3(
                tile.position.x,
                tile.position.y,
                board.transform.position.z - board.itemZDistanceFactor
            );

            InstantiableItem instatiableItem = this._itemProvider.GetRandomItem();
            Debug.Log($" O random foi: {instatiableItem.itemPrefab.name}");

            Item item = Instantiate(instatiableItem.itemPrefab, spawnPos, Quaternion.identity, tile.obj.transform);
            tile.item = item;
        }
    }
}
