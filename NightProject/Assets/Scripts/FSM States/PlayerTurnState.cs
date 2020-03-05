using UnityEngine;

public class PlayerTurnState : State
{
    private GameObject selectedEnemyUnit;
    private Camera mainCamera;

    public override void OnStateEnter()
    {
        Debug.Log("Entered PlayerTurn State");

        SelectFirstUnit();
        SetUnitOutline(battleSystem.selectedAlliedUnit, true);

        mainCamera = battleSystem.mainCamera;
    }

    public override void Update()
    {
        SelectInput();
    }

    private void SelectInput()
    {
        Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (raycastHit2D.collider != null && raycastHit2D.collider.GetComponent<ISelectUnit>() != null)
        {
            ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();
            MouseOverEnemy(selectable);

            if (Input.GetMouseButtonDown(0))
            {
                // if ally select, if enemy attack
                SelectUnit(selectable);
            }
        }
    }

    private void SetUnitOutline(GameObject selectedUnit, bool activate)
    {
        if (activate)
        {
            selectedUnit.GetComponentInChildren<Outline>().active = true;
            selectedUnit.GetComponentInChildren<Outline>().flag = true;
        }
        else
        {
            selectedUnit.GetComponentInChildren<Outline>().active = false;
            selectedUnit.GetComponentInChildren<Outline>().flag = true;
        }
    }

    private void SelectFirstUnit()
    {
        int childCount = battleSystem.alliedUnitPlatforms.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            if (battleSystem.alliedUnitPlatforms.transform.GetChild(i).GetComponentInChildren<Unit>())
            {
                battleSystem.selectedAlliedUnit = battleSystem.alliedUnitPlatforms.transform.GetChild(i).gameObject;

                Debug.Log("Selected Child " + battleSystem.selectedAlliedUnit.name);
            break;
            }
        }
    }

    private void SelectUnit(ISelectUnit selectable)
    {
        if (selectable.GetSelectedUnit.transform.parent.parent.gameObject == battleSystem.alliedUnitPlatforms)
        {
            SetUnitOutline(battleSystem.selectedAlliedUnit, false);
            battleSystem.selectedAlliedUnit = selectable.GetSelectedUnit;
            SetUnitOutline(battleSystem.selectedAlliedUnit, true);
            Debug.Log("Selected Unit " + battleSystem.selectedAlliedUnit.GetComponent<Unit>().UnitData.Name);
        }
    }

    private void MouseOverEnemy(ISelectUnit selectable)
    {
        if (selectable.GetSelectedUnit.transform.parent.parent.gameObject == battleSystem.enemyUnitPlatforms)
        {
            if (selectedEnemyUnit != null)
            {
                if (selectable.GetSelectedUnit != selectedEnemyUnit)
                {
                    SetUnitOutline(selectedEnemyUnit, false);
                    selectedEnemyUnit = selectable.GetSelectedUnit;
                    SetUnitOutline(selectedEnemyUnit, true);

                    Debug.Log("Mouse Over " + selectedEnemyUnit.GetComponent<Unit>().UnitData.Name);
                }
            }
            else
            {
                selectedEnemyUnit = selectable.GetSelectedUnit;
                SetUnitOutline(selectedEnemyUnit, true);
            }
        }
    }
}