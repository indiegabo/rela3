using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleModeState : State
{
    // Needed Components
    protected readonly SimpleMode _simpleMode;

    public SimpleModeState(SimpleMode simpleMode)
    {
        this._simpleMode = simpleMode;
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
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
    }
}
