using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionSelectionState : State
{
    public override void OnStateEnter()
    {
        Debug.Log("Entered FactionSelection State");
        AddListeners();
    }

    private void AddListeners()
    {
        for (int i = 0; i < battleSystem.instantiateUnitCards.factionButtons.Length; i++)
        {
            int factionIndex = i;
            battleSystem.instantiateUnitCards.factionButtons[i].onClick.AddListener(() => battleSystem.instantiateUnitCards.CheckUnitFaction(battleSystem.instantiateUnitCards.unitFactions[factionIndex]));
            battleSystem.instantiateUnitCards.factionButtons[i].onClick.AddListener(() => battleSystem.SwitchState(new UnitSelectionState()));
        }
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting FactionSelection State");
    }
}
