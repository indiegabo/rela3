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

        this.CheckMatches();

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

    private void CheckMatches()
    {
        if (this._board.swapedFrom == null || this._board.swapedTo == null) return;

        this.FindHorizontalMatches(_board.swapedTo);
        this.FindHorizontalMatches(_board.swapedFrom);
    }

    private void FindHorizontalMatches(Tile tile)
    {
        List<Tile> sameTypeItemsTiles = new List<Tile>();

        Tile previous = this._board.GetTile(new Vector2(tile.position.x - 1, tile.position.y));
        Tile next = this._board.GetTile(new Vector2(tile.position.x + 1, tile.position.y));

        while (previous != null && tile.item.type == previous.item.type)
        {
            sameTypeItemsTiles.Add(previous);
            previous = this._board.GetTile(new Vector2(previous.position.x - 1, tile.position.y));
        }

        while (next != null && tile.item.type == next.item.type)
        {
            sameTypeItemsTiles.Add(next);
            next = this._board.GetTile(new Vector2(next.position.x + 1, tile.position.y));
        }

        if (sameTypeItemsTiles.Count >= 2)
        {
            sameTypeItemsTiles.Add(tile);
            sameTypeItemsTiles = sameTypeItemsTiles.OrderBy(tile => tile.position.x).ToList<Tile>();
        }
        else
        {
            sameTypeItemsTiles.Clear();
        }

        foreach (Tile dTile in sameTypeItemsTiles)
        {
            Debug.Log($"Tile [{dTile.position.x}][{dTile.position.y}] - {dTile.item.type}");
        }
    }
}
