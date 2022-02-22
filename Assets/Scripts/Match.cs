using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match
{
    public List<Tile> tiles { get; private set; }

    public Match(List<Tile> matchedTiles)
    {
        this.tiles = matchedTiles;
    }

    public int size => this.tiles.Count;

}
