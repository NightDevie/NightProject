using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : State
{
    private Unit Unit => battleSystem.alliedUnitPlatforms.GetComponentInChildren<Unit>();

    public override void OnStateEnter()
    {
        Debug.Log("Entered PlayerTurn State");


        battleSystem.selectedUnit = battleSystem.alliedUnitPlatforms.GetComponentInChildren<Unit>().gameObject;
        Debug.Log("Selected child " + battleSystem.selectedUnit.name);
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

    public override void SelectUnit(RaycastHit2D raycastHit2D)
    {
        ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();

        if (selectable != null)
        {
            if(selectable.GetSelectedUnit.transform.parent.parent.gameObject == battleSystem.alliedUnitPlatforms)
            {
                battleSystem.selectedUnit = selectable.GetSelectedUnit;
                Debug.Log("Selected Unit " + battleSystem.selectedUnit.GetComponent<Unit>().UnitData.Name);
            }
        }
    }
}