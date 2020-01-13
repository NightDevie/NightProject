using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Inventory unitInventory;
    public RectTransform rectTransform;
    public GameObject unitPrefab;
    public GameObject parentObject;

    public void Start()
    {
        SpawnObjects();
    }
    public void SpawnObjects() // unitInventory.Items[i]
    {
        for (int i = 0; i < unitInventory.Items.Count; i++)
        {
            for (int i0 = 0; i0 < unitInventory.Items[i].amount; i0++)
            {
                Instantiate(unitPrefab, parentObject.transform);
                unitPrefab.GetComponent<Unit>().setUnitData(unitInventory.Items[i].item);
                //instantiatedPrefab.transform.SetParent(parentObject.transform);
                //instantiatedPrefab.transform.SetAsLastSibling();
            }
        }
    }
}