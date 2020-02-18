using UnityEngine;

public class UnitSelectionState : State
{
    public override void OnStateEnter()
    {
        Debug.Log("Entered UnitSelection State");
    }

    public override void Update()
    {
        SelectInput();
        FightButtonSetActive();
    }

    private void SelectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera mainCamera = battleSystem.mainCamera;
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (raycastHit2D.collider != null)
            {
                Debug.Log("Has Collider");
                SelectUnitParent(raycastHit2D);
                RemoveUnit(raycastHit2D);
            }
        }
    }

    private void RemoveUnit(RaycastHit2D raycastHit2D)
    {
        ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();

        if (selectable != null)
        {
            for (int i = 0; i < battleSystem.alliedUnitPlatforms.GetComponentsInChildren<Unit>().Length; i++)
            {
                if (battleSystem.unitCards.transform.GetChild(i).GetComponent<Unit>().Name == selectable.GetSelectedUnit.GetComponent<Unit>().Name)
                {
                    Unit unit = battleSystem.unitCards.transform.GetChild(i).GetComponent<Unit>();
                    unit.Amount ++;
                    
                    selectable.GetSelectedUnit.GetComponent<Unit>().DestroyParentObject();

                    battleSystem.unitCards.transform.GetChild(i).GetComponent<UnitCardUI>().EditorUnitCardUIUpdate();
                    Debug.Log("Removed " + unit.Name);
            break;
                }
            }
        }
    }

    private void FightButtonSetActive()
    {
        if (battleSystem.alliedUnitPlatforms.GetComponentInChildren<Unit>())
        {
            battleSystem.startFight.SetActive(true);
        }
        else
        {
            battleSystem.startFight.SetActive(false);
        }
    }
}