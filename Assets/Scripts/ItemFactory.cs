using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] [Range(0.01f, 0.1f)] private float _populateSpawnDelay = 0.05f;

    // Needed components
    private ItemProvider _itemProvider;

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
        for (int y = 0; y < board.ySize; y++)
        {
            for (int x = 0; x < board.xSize; x++)
            {
                this.SpawnRandomItem(board.GetTile(new Vector2(x, y)));
                yield return new WaitForSeconds(this._populateSpawnDelay);
            }
        }
    }

    public void SpawnRandomItem(Tile tile)
    {
        Vector3 startingPos = new Vector3(tile.position.x, 20f, 0);
        List<ItemType> blockedItems = new List<ItemType>();
        // Identify horizontally blocked item
        // Identify vertically blocked item

        GameObject itemPrefab = this._itemProvider.GetRandomItem(blockedItems);
        // ItemType itemType = itemPrefab.GetComponent<ItemType>();



        // (x == x+1 && x == x+2) || (x == x-1 && x == x-2) || (y == y+1 && y == y+2) || (y == y-1 && y == y-2)
        GameObject item = Instantiate(itemPrefab, startingPos, Quaternion.identity, tile.obj.transform);

        ITransition itemTransition = item.GetComponent<ITransition>();
        itemTransition.TransitionTo(tile);
    }
}
