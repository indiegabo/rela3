using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int _xSize = 8;
    [SerializeField] private int _ySize = 8;
    [SerializeField] private GameObject _tileEvenPrefab;
    [SerializeField] private GameObject _tileOddPrefab;

    public Dictionary<Vector2, Tile> tiles { get; private set; }

    public int xSize => this._xSize;
    public int ySize => this._ySize;

    private void Awake()
    {
        this.tiles = new Dictionary<Vector2, Tile>();
    }

    public void Initialize()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
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
}
