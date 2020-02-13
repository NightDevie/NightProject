﻿using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedUnit;
    [HideInInspector]
    public GameObject selectedParent;

    public Camera mainCamera;
    private State state;

    private void Start()
    {
        SwitchState(new PlayerTurnState());
        state.battleSystem = this;
    }

    private void Update()
    {
        state?.Update();
    }

    public void SwitchState(State newState)
    {
        state?.OnStateExit();
        state = newState;
        state?.OnStateEnter();
    }
}