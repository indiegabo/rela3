using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Vector2 position;
    public string name;
    public GameObject obj;
    public Item item { get; set; }

    public Tile(Vector2 position, string name, GameObject obj)
    {
        this.position = position;
        this.name = name;
        this.obj = obj;
    }

    // public GameObject TryGetChildObject(out GameObject childObject)
    // {
    //     childObject = this.obj.gameObject.transform.GetChild(0).gameObject;
    //     return childObject;
    // }
}
