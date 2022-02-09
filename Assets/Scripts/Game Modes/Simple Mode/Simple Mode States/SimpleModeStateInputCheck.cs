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
        Debug.Log(positionOnGrid);
    }

    public void OnGrabFinish(Vector2 positionOnGrid)
    {
        Vector2 distance = (positionOnGrid - this._grabStartedAt).normalized;

        if (distance == Vector2.left)
            Debug.Log("Move Left");

        if (distance == Vector2.right)
            Debug.Log("Move Right");

        if (distance == Vector2.up)
            Debug.Log("Move Up");

        if (distance == Vector2.down)
            Debug.Log("Move Down");
    }
}
