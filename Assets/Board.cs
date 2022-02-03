using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int xSize = 8;
    [SerializeField] private int ySize = 8;
    [SerializeField] private GameObject _tileEvenPrefab;
    [SerializeField] private GameObject _tileOddPrefab;

    private static Dictionary<Vector3, Tile> _tiles;

    private void Awake()
    {
        _tiles = new Dictionary<Vector3, Tile>();
        this.Initialize();
    }

    private void Initialize()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                // Instantiate tile
                Vector3 position = new Vector3(x, y, this.transform.position.z);
                string name = string.Format("Tile [{0}][{1}]", x, y);
                GameObject obj = this.GenerateObj(position, name);
                Tile tile = new Tile(position, name, obj);
                _tiles.Add(position, tile);
            }
        }
    }

    private GameObject GenerateObj(Vector3 position, string name)
    {
        bool bothEven = (position.x % 2) == (position.y % 2);
        GameObject tileObject = Instantiate(bothEven ? this._tileEvenPrefab : this._tileOddPrefab, position, Quaternion.identity, this.transform);
        tileObject.name = name;
        return tileObject;
    }

    public static Tile GetTile(Vector3 position)
    {
        Tile tile = null;
        _tiles.TryGetValue(position, out tile);
        return tile;
    }
}
