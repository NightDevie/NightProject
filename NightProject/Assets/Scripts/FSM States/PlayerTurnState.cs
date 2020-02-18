using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : State
{
    public override void Update()
    {
        SelectInput();
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
                SelectUnit(raycastHit2D);
            }
        }
    }

    public override void SelectUnit(RaycastHit2D raycastHit2D)
    {
        base.SelectUnit(raycastHit2D);
    }
}