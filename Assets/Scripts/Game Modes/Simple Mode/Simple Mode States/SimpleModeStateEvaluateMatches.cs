using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleModeStateEvaluateMatches : SimpleModeState
{
    public SimpleModeStateEvaluateMatches(SimpleMode simpleMode) : base(simpleMode)
    {
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

        Debug.Log("Verificando matches...");

        _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateInputCheck);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
