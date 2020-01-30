using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject selectedUnit;
    public Unit unit;

    private void Update()
    {
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
                Debug.Log(2);
                ISelectable selectable = hit.collider.GetComponent<ISelectable>();

                if (selectable != null)
                {
                    selectedUnit = selectable.Selected();
                    Debug.Log(selectedUnit.name);
                }
            }
        }
    }
}