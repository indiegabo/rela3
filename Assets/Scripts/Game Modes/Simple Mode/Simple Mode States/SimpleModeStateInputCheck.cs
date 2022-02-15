using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleModeStateInputCheck : SimpleModeState
{

    private Vector2 _grabStartedAt;

    public SimpleModeStateInputCheck(SimpleMode simpleMode) : base(simpleMode)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {

    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public override void FixedTick()
    {

    }
    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        Debug.Log("Entered Input Check State");
        InputHandler.onStartGrab += this.OnGrabStart;
        InputHandler.onFinishedGrab += this.OnGrabFinish;
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        InputHandler.onStartGrab -= this.OnGrabStart;
        InputHandler.onFinishedGrab -= this.OnGrabFinish;
    }

    public void OnGrabStart(Vector2 positionOnGrid)
    {
        this._grabStartedAt = positionOnGrid;
    }

    public void OnGrabFinish(Vector2 positionOnGrid)
    {
        Vector2 distance = (positionOnGrid - this._grabStartedAt).normalized;

        //Store initial tile and final tile in a variable
        Tile initialTile = _simpleMode.core.board.GetTile(this._grabStartedAt);
        Tile finalTile = _simpleMode.core.board.GetTile(this._grabStartedAt + distance);
        
        //If any of the tiles is null, or they are the same, do nothing
        if (initialTile == null || finalTile == null || (initialTile.position == finalTile.position)) return;

        //Switch tile item references
        Item initialTileItem = initialTile.item;
        Item finalTileItem = finalTile.item;

        initialTile.item = finalTileItem;
        finalTile.item = initialTileItem;

        //Switch parents
        initialTile.item.transform.parent = initialTile.obj.transform;
        finalTile.item.transform.parent = finalTile.obj.transform;

        //Set item positions to its tile position (0f,0f)
        initialTile.item.transform.localPosition = new Vector3(0f, 0f, -5f);
        finalTile.item.transform.localPosition = new Vector3(0f, 0f, -5f);

        _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateCheckTiles);
    }
}
