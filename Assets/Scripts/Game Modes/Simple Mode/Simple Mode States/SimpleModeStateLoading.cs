using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleModeStateLoading : SimpleModeState
{

    public SimpleModeStateLoading(SimpleMode simpleMode) : base(simpleMode)
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
        this._simpleMode.core.itemProvider.Initialize();
        Debug.Log("Provider Initialized");
        this._simpleMode.core.board.Initialize();
        Debug.Log("Board Initialized");

        // TODO: Populate board

        this._simpleMode.ChangeState(this._simpleMode.simpleModeStateInputCheck);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
    }
}
