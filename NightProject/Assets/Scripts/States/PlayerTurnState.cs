using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : State
{
    public override void Update()
    {
        SelectInput();
    }

    public void SelectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera mainCamera = battleSystem.mainCamera;
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (raycastHit2D.collider != null)
            {
                SelectUnit(raycastHit2D);
                SelectUnitParent(raycastHit2D);

            }
        }

    }

    private void SelectUnit(RaycastHit2D raycastHit2D)
    {
        Debug.Log("Has Collider");
        ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();

        if (selectable != null)
        {
            battleSystem.selectedUnit = selectable.GetSelectedUnit;
            Debug.Log("Is Unit " + battleSystem.selectedUnit.GetComponent<Unit>().unitData.UnitName);
        }
    }

    private void SelectUnitParent(RaycastHit2D raycastHit2D)
    {
        Debug.Log("Has Collider");
        ISelectUnitParent selectable = raycastHit2D.collider.GetComponent<ISelectUnitParent>();

        if (selectable != null)
        {
            battleSystem.selectedParent = selectable.GetSelectedUnitParent;
            Debug.Log("Is Parent " + battleSystem.selectedParent.name);
        }
    }
}