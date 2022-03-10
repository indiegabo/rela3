using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3.StateManagement;
using UnityEngine;

public abstract class Entity<T> : MonoBehaviour where T : EntityCore
{
    public StateMachine stateMachine { get; private set; }
    protected T _core;

    public T core => this._core;

    protected virtual void Awake()
    {
        // Gets the entity core
        this._core = GetComponent<T>();

        // Initialize State Machine
        this.stateMachine = new StateMachine();
    }


    protected virtual void Update()
    {
        this.stateMachine.Tick();
    }

    protected virtual void FixedUpdate()
    {
        this.stateMachine.FixedTick();
    }

    /// <summary>
    /// Changes Entity active state
    /// </summary>
    /// <param name="state"></param>//
    public virtual void ChangeState(State state)
    {
        this.stateMachine.SetActiveState(state);
    }
}
