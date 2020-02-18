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

    public virtual void SelectUnitParent(RaycastHit2D raycastHit2D)
    {
        ISelectUnitParent selectable = raycastHit2D.collider.GetComponent<ISelectUnitParent>();

        if (selectable != null)
        {
            battleSystem.selectedParent = selectable.GetSelectedUnitParent;
            Debug.Log("Selected Parent = " + battleSystem.selectedParent.name);
        }
    }
    public virtual void SelectUnit(RaycastHit2D raycastHit2D)
    {
        ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();

        if (selectable != null)
        {
            battleSystem.selectedUnit = selectable.GetSelectedUnit;
            Debug.Log("Selected Unit " + battleSystem.selectedUnit.GetComponent<Unit>().UnitData.Name);
        }
    }
}