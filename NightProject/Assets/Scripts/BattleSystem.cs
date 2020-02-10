using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedUnit;
    [HideInInspector]
    public GameObject selectedParent;

    public Camera mainCamera;
    static StartState start;
    static ChooseFactionState chooseFaction;
    static ChooseUnitsState chooseUnits;
    static PlayerTurnState playerTurn;
    static EnemyTurnState enemyTurn;
    static WonState won;
    static LostState lost;

    public BattleSystem battleSystem;
    public State state;

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