using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public GameObject selectedParent;
    public Unit unit;

    private void Update()
    {
        // if '' = true
        SelectParent();
        // if '' = true
        SelectUnit();
    }

    private void SelectUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Unit");
                ISelectUnit selectable = hit.collider.GetComponent<ISelectUnit>();

                if (selectable != null)
                {
                    selectedUnit = selectable.GetSelectedUnit();
                    Debug.Log(selectedUnit.GetComponent<Unit>().unitData.getUnitName());
                    Debug.Log("222Unit");
                }
            }
        }
    }

    private void SelectParent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Parent");
                ISelectParent selectable = hit.collider.GetComponent<ISelectParent>();

                if (selectable != null)
                {
                    selectedParent = selectable.GetSelectedParent();
                    Debug.Log(selectedParent.name);
                    Debug.Log("222Parent");
                }
            }
        }
    }
}