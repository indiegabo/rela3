using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMode : Entity<SimpleModeCore>
{

    private SimpleModeStateLoading _simpleModeStateLoading;

    private void Start()
    {
        this.LoadStates();

        this.stateMachine.SetActiveState(this._simpleModeStateLoading);
    }

    private void LoadStates()
    {
        this._simpleModeStateLoading = new SimpleModeStateLoading(this);
    }

}
