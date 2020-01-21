using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject SelectedUnit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                ISelectable selectable = hit.collider.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    SelectedUnit = hit.collider.gameObject;
                    Debug.Log(1);
                }
            }
        }
    }
}