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

    [Header("Objects")]
    [SerializeField] private List<GameObject> _itemsList;

    private static Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        this.Initialize();
    }

    private void Start()
    {
        this.SpawnAccordion();
        this.SpawnStrawHat();
    }

    private void Initialize()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                // Instantiate tile
                Vector2 position = new Vector2(x, y);
                string name = string.Format("Tile [{0}][{1}]", x, y);
                GameObject obj = this.GenerateObj(position, name);
                Tile tile = new Tile(position, name, obj);
                _tiles.Add(position, tile);
            }
        }
    }

    private GameObject GenerateObj(Vector2 boardPosition, string name)
    {
        Vector3 position = new Vector3(boardPosition.x, boardPosition.y, transform.position.z);

        bool bothEven = (boardPosition.x % 2) == (boardPosition.y % 2);

        GameObject tileObject = Instantiate(bothEven ? this._tileEvenPrefab : this._tileOddPrefab, position, Quaternion.identity, this.transform);
        tileObject.name = name;
        return tileObject;
    }

    public static Tile GetTile(Vector2 position)
    {
        Tile tile = null;
        _tiles.TryGetValue(position, out tile);
        return tile;
    }

    private void SpawnAccordion()
    {
        Tile destinationTile = GetTile(new Vector2(0, 0));
        Debug.Log(destinationTile.position);
        Vector3 startingPos = new Vector3(2, 20f, 0);

        GameObject accordionPrefab = ItemServer.GetItemOfType(ItemType.Accordion);
        GameObject accordion = Instantiate(accordionPrefab, startingPos, Quaternion.identity, transform.parent);

        ITransition accordionTransition = accordion.GetComponent<ITransition>();
        accordionTransition.TransitionTo(destinationTile);
    }

    private void SpawnStrawHat()
    {
        Tile destinationTile = GetTile(new Vector2(1, 0));
        Debug.Log(destinationTile.position);
        Vector2 startingPos = new Vector2(0, 20f);

        GameObject strawHatPrefab = ItemServer.GetItemOfType(ItemType.StrawHat);
        GameObject strawHat = Instantiate(strawHatPrefab, startingPos, Quaternion.identity, transform.parent);

        ITransition strawHatTransition = strawHat.GetComponent<ITransition>();
        strawHatTransition.TransitionTo(destinationTile);
    }

}
