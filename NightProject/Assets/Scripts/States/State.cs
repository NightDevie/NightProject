using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public BattleSystem battleSystem;

    public virtual void OnStateEnter() { }
    public virtual void Update() { }
    public virtual void HandleInput() { }
    public virtual void OnStateExit() { }
}