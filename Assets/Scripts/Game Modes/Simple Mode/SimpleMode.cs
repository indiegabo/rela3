using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMode : Entity<SimpleModeCore>
{

    public SimpleModeStateLoading simpleModeStateLoading;
    public SimpleModeStateInputCheck simpleModeStateInputCheck;

    private void Start()
    {
        this.LoadStates();

        this.stateMachine.SetActiveState(this.simpleModeStateLoading);
    }

    private void LoadStates()
    {
        this.simpleModeStateLoading = new SimpleModeStateLoading(this);
        this.simpleModeStateInputCheck = new SimpleModeStateInputCheck(this);
    }

}
