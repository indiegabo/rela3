using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IA;
using IndieGabo.Rela3.Items;

namespace IndieGabo.Rela3
{
    public class Board : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField][Range(1f, 10f)] public float itemZDistanceFactor = 5f;
        [SerializeField][Range(1f, 10f)] public float firstSpawnYDistanceFactor = 5f;
        [SerializeField] private int _xSize = 8;
        [SerializeField] private int _ySize = 8;
        [SerializeField] private GameObject _tileEvenPrefab;
        [SerializeField] private GameObject _tileOddPrefab;

        public Tile swapedA;
        public Tile swapedB;
        public List<Match> currentMatches = new List<Match>();
        public Dijkstra dijkstra { get; private set; }

        public Dictionary<Vector2, Tile> tiles { get; private set; }

        public int columns => this._xSize;
        public int rows => this._ySize;

        public int instatiateRowPos => this._ySize;

        private void Awake()
        {
            this.dijkstra = GetComponent<Dijkstra>();
            this.tiles = new Dictionary<Vector2, Tile>();
        }

        public void Initialize()
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    // Instantiate tile
                    Vector2 position = new Vector2(x, y);
                    string name = string.Format("Tile [{0}][{1}]", x, y);
                    GameObject obj = this.GenerateTile(position, name);
                    Tile tile = new Tile(position, name, obj);
                    this.tiles.Add(position, tile);
                }
            }
        }

        private GameObject GenerateTile(Vector2 boardPosition, string name)
        {
            Vector3 position = new Vector3(boardPosition.x, boardPosition.y, transform.position.z);

            bool bothEven = (boardPosition.x % 2) == (boardPosition.y % 2);

            GameObject tileObject = Instantiate(bothEven ? this._tileEvenPrefab : this._tileOddPrefab, position, Quaternion.identity, this.transform);
            tileObject.name = name;
            return tileObject;
        }

        public Tile GetTile(Vector2 position)
        {
            this.tiles.TryGetValue(position, out Tile tile);
            return tile;
        }

        public Tile LastColumnTile(int x)
        {
            return this.GetTile(new Vector2(x, this._ySize - 1));
        }

        public Tile GetTileByItemType(Vector2 position, ItemType itemType)
        {
            this.tiles.TryGetValue(position, out Tile tile);
            return (tile != null && itemType == tile.item.type) ? tile : null;
        }

        public void SwapTilesItems(Tile from, Tile to)
        {

            //Switch tile item references
            Item fromItem = from.item;
            Item toItem = to.item;

            // Swap occurs here
            from.item = toItem;
            to.item = fromItem;

            //Switch parents
            from.item.transform.parent = from.obj.transform;
            to.item.transform.parent = to.obj.transform;

            //Set item positions to its tile position (0f,0f)
            from.item.transform.localPosition = new Vector3(0f, 0f, -5f);
            to.item.transform.localPosition = new Vector3(0f, 0f, -5f);
        }

        public Match ScanMatch(Tile from)
        {

            List<Tile> path = this.dijkstra.FindPath(from);

            if (path.Count >= 3)
            {
                return new Match(path);
            }
            else
            {
                return null;
            }
        }


        public void EvaluateMatch(Tile tile)
        {
            Match match = this.ScanMatch(tile);

            if (match == null) return;

            this.currentMatches.Add(match);
        }

        public void ApplyMatch(Match match)
        {
            if (match == null) return;

            foreach (Tile tile in match.tiles)
            {
                tile.RemoveItem();
            }
        }

        // Debug Stuff
        private void DebugTiles(List<Tile> tiles, string title = "Debugging List:")
        {
            if (tiles.Count <= 0) return;

            Debug.Log(title);

            foreach (Tile dTile in tiles)
            {
                Debug.Log($"Tile [{dTile.position.x}][{dTile.position.y}] - {dTile.item.type}");
            }
        }
    }
}
