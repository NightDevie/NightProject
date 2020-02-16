using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public override void OnStateEnter()
    {
        Debug.Log("Entered Start State");
        battleSystem.SwitchState(new FactionSelectionState());
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting Start State");
    }
}