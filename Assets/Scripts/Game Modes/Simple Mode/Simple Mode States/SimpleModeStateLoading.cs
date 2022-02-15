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
        ItemFactory itemFactory = this._simpleMode.core.itemFactory;
        Board board = this._simpleMode.core.board;

        board.Initialize();
        Debug.Log("Board Initialized");

        itemFactory.Initialize();
        Debug.Log("Factory Initialized");

        itemFactory.PopulateBoard(board);
        Debug.Log("Board Populated");

        this._simpleMode.ChangeState(this._simpleMode.simpleModeStateInputCheck);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {

    }
}
