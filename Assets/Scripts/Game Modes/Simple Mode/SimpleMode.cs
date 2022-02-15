using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMode : Entity<SimpleModeCore>
{

    public SimpleModeStateLoading simpleModeStateLoading;
    public SimpleModeStateInputCheck simpleModeStateInputCheck;
    public SimpleModeStateCheckTiles simpleModeStateCheckTiles;

    private void Start()
    {
        this.LoadStates();

        this.stateMachine.SetActiveState(this.simpleModeStateLoading);
    }

    private void LoadStates()
    {
        this.simpleModeStateLoading = new SimpleModeStateLoading(this);
        this.simpleModeStateInputCheck = new SimpleModeStateInputCheck(this);
        this.simpleModeStateCheckTiles = new SimpleModeStateCheckTiles(this);
    }

}
