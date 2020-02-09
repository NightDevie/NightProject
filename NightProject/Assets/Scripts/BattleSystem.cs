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
    static PlayerTurnState playerTurn;
    static EnemyTurnState enemyTurn;
    static WonState won;
    static LostState lost;

    private State state;

    private void Update()
    {
        SwitchState(new StartState());
        state?.Update();
    }

    public void SwitchState(State newState)
    {
        state?.OnExit();
        state = newState;
        state?.OnEnter();
    }

    private void SelectUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Has Collider");
                ISelectUnit selectable = hit.collider.GetComponent<ISelectUnit>();

                if (selectable != null)
                {
                    selectedUnit = selectable.GetSelectedUnit;
                    Debug.Log("Is Unit " + selectedUnit.GetComponent<Unit>().unitData.UnitName);
                }
            }
        }
    }

    private void SelectUnitParent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Has Collider");
                ISelectUnitParent selectable = hit.collider.GetComponent<ISelectUnitParent>();

                if (selectable != null)
                {
                    selectedParent = selectable.GetSelectedUnitParent;
                    Debug.Log("Is Parent " + selectedParent.name);
                }
            }
        }
    }
}