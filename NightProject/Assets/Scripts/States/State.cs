using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    private State state;

    public virtual void Update() { }
    public virtual void HandleInput() { }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
}