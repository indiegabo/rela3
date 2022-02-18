using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimpleModeStateEvaluateMatches : SimpleModeState
{
    private Board _board;

    public SimpleModeStateEvaluateMatches(SimpleMode simpleMode) : base(simpleMode)
    {
        this._board = simpleMode.core.board;
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("Evaluating matches...");

        this.CheckMatches(_board.swapedTo);
        this.CheckMatches(_board.swapedFrom);

        _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateInputCheck);
    }

    public override void OnExit()
    {
        base.OnExit();
        if (this._board.swapedFrom != null || this._board.swapedTo != null)
        {
            // TODO: Swap back
        }
    }

    private void CheckMatches(Tile tile)
    {
        Debug.Log($"Finding Horizontal Matches for [{tile.position.x}][{tile.position.y}] - Type: {tile.item.type}");
        this.FindHorizontalMatches(tile);

        Debug.Log($"Finding Vertical Matches for [{tile.position.x}][{tile.position.y}] - Type: {tile.item.type}");
        this.FindVerticalMatches(tile);
    }

    private void FindHorizontalMatches(Tile tile)
    {
        List<Tile> sameTypeItemsTiles = new List<Tile>();

        Tile previous = this._board.GetTileByItemType(new Vector2(tile.position.x - 1, tile.position.y), tile.item.type);
        Tile next = this._board.GetTileByItemType(new Vector2(tile.position.x + 1, tile.position.y), tile.item.type);

        while (previous != null)
        {
            sameTypeItemsTiles.Add(previous);
            previous = this._board.GetTileByItemType(new Vector2(previous.position.x - 1, tile.position.y), tile.item.type);
        }

        while (next != null)
        {
            sameTypeItemsTiles.Add(next);
            next = this._board.GetTileByItemType(new Vector2(next.position.x + 1, tile.position.y), tile.item.type);
        }

        if (sameTypeItemsTiles.Count >= 2)
        {
            // Match happened
            sameTypeItemsTiles.Add(tile);
            sameTypeItemsTiles = sameTypeItemsTiles.OrderBy(tile => tile.position.x).ToList<Tile>();
        }
        else
        {
            sameTypeItemsTiles.Clear();
        }

        DebugTiles(sameTypeItemsTiles, "Same Horizontal Items Types:");
    }
    private void FindVerticalMatches(Tile tile)
    {
        List<Tile> sameTypeItemsTiles = new List<Tile>();

        Tile previous = this._board.GetTileByItemType(new Vector2(tile.position.x, tile.position.y - 1), tile.item.type);
        Tile next = this._board.GetTileByItemType(new Vector2(tile.position.x, tile.position.y + 1), tile.item.type);

        while (previous != null)
        {
            sameTypeItemsTiles.Add(previous);
            previous = this._board.GetTileByItemType(new Vector2(tile.position.x, previous.position.y - 1), tile.item.type);
        }

        while (next != null)
        {
            sameTypeItemsTiles.Add(next);
            next = this._board.GetTileByItemType(new Vector2(tile.position.x, next.position.y + 1), tile.item.type);
        }

        if (sameTypeItemsTiles.Count >= 2)
        {
            // Match happened
            sameTypeItemsTiles.Add(tile);
            sameTypeItemsTiles = sameTypeItemsTiles.OrderBy(tile => tile.position.y).ToList<Tile>();
        }
        else
        {
            sameTypeItemsTiles.Clear();
        }

        DebugTiles(sameTypeItemsTiles, "Same Vertical Items Types:");
    }

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
