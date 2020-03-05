using UnityEngine;
using UnityEngine.UI;

public class UnitSelectionState : State
{
    private Unit Unit => battleSystem.alliedUnitPlatforms.GetComponentInChildren<Unit>();

    public override void OnStateEnter()
    {
        Debug.Log("Entered UnitSelection State");

        battleSystem.startFight.GetComponent<Button>().onClick.AddListener(() => battleSystem.SwitchState(new PlayerTurnState()));
        battleSystem.startFight.GetComponent<Button>().onClick.AddListener(() => DisablePlatformSprites());
    }

    public override void Update()
    {
        SelectInput();
        FightButtonSetActive();
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting UnitSelection State");
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

    private void SelectUnitParent(RaycastHit2D raycastHit2D)
    {
        ISelectUnitParent selectable = raycastHit2D.collider.GetComponent<ISelectUnitParent>();

        if (selectable != null)
        {
            battleSystem.selectedParent = selectable.GetSelectedUnitParent;
            Debug.Log("Selected Parent = " + battleSystem.selectedParent.name);
        }
    }

    private void RemoveUnit(RaycastHit2D raycastHit2D)
    {
        ISelectUnit selectable = raycastHit2D.collider.GetComponent<ISelectUnit>();

        if (selectable != null && selectable.GetSelectedUnit.transform.parent.parent.gameObject == battleSystem.alliedUnitPlatforms)
        {
            for (int i = 0; i < battleSystem.alliedUnitPlatforms.GetComponentsInChildren<Unit>().Length; i++)
            {
                if (battleSystem.unitCards.transform.GetChild(i).GetComponent<Unit>().Name == selectable.GetSelectedUnit.GetComponent<Unit>().Name)
                {
                    Unit unit = battleSystem.unitCards.transform.GetChild(i).GetComponent<Unit>();
                    unit.Amount++;

                    selectable.GetSelectedUnit.GetComponent<Unit>().DestroyParentObject();
#if UNITY_EDITOR
                    battleSystem.unitCards.transform.GetChild(i).GetComponent<UnitCardUI>().EditorUnitCardUIUpdate();
#endif
                    Debug.Log("Removed " + unit.Name);
                break;
                }
            }
        }
    }

    private void FightButtonSetActive()
    {
        if (Unit == true)
        {
            battleSystem.startFight.SetActive(true);
        }
        else if (battleSystem.startFight.activeSelf)
        {
            battleSystem.startFight.SetActive(false);
        }
    }

    private void DisablePlatformSprites()
    {
        for (int i = 0; i < battleSystem.alliedUnitPlatforms.transform.childCount; i++)
        {
            battleSystem.alliedUnitPlatforms.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}