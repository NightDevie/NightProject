using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : State
{
    private Unit Unit => battleSystem.alliedUnitPlatforms.GetComponentInChildren<Unit>();

    public override void OnStateEnter()
    {
        Debug.Log("Entered PlayerTurn State");

        SetFirstUnitOutline();
    }

    public override void Update()
    {
        SelectInput();
    }

    private void SelectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Unit == true)
            {
                Camera mainCamera = battleSystem.mainCamera;
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
                
                if (raycastHit2D.collider != null)
                {
                    Debug.Log("Has Collider");
                    SelectUnit(raycastHit2D);
                } 
            }
        }
    }

    private void SetUnitOutline(GameObject selectedUnit, bool isActive)
    {
        if (isActive)
        {
            selectedUnit.GetComponentInChildren<Outline>().active = true;
        }
        else
        {
            selectedUnit.GetComponentInChildren<Outline>().active = false;
        }
    }

    private void SetFirstUnitOutline()
    {
        int childCount = battleSystem.alliedUnitPlatforms.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            if (battleSystem.alliedUnitPlatforms.transform.GetChild(i).GetComponentInChildren<Unit>())
            {
                battleSystem.selectedUnit = battleSystem.alliedUnitPlatforms.transform.GetChild(i).gameObject;
                SetUnitOutline(battleSystem.selectedUnit, true);

                Debug.Log("Selected child " + battleSystem.selectedUnit.name);
            break;
            }
        }
    }

    public override void SelectUnit(RaycastHit2D raycastHit2D)
    {
        ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();

        if (selectable != null)
        {
            if(selectable.GetSelectedUnit.transform.parent.parent.gameObject == battleSystem.alliedUnitPlatforms)
            {
                SetUnitOutline(battleSystem.selectedUnit, false);
                battleSystem.selectedUnit = selectable.GetSelectedUnit;
                SetUnitOutline(battleSystem.selectedUnit, true);
                Debug.Log("Selected Unit " + battleSystem.selectedUnit.GetComponent<Unit>().UnitData.Name);
            }
        }
    }
}