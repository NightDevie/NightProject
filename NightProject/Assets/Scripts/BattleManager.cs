using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Inventory unitInventory;
    public RectTransform rectTransform;
    public GameObject unitPrefab;
    public GameObject instantiatedPrefab;
    public GameObject parentObject;
    public GameObject selectedObject;
    
    public void Start()
    {
        SpawnObjects();
    }
    public void SpawnObjects() // unitInventory.Items[i] // for (int i0 = 0; i0 < unitInventory.Items[i].amount; i0++){}
    {
        for (int i = 0; i < unitInventory.Items.Count;)
        {
            instantiatedPrefab = Instantiate(unitPrefab, parentObject.transform);
            instantiatedPrefab.GetComponent<Unit>().setUnitData(unitInventory.Items[i].item);
            instantiatedPrefab.GetComponent<Unit>().setUnitAmount(unitInventory.Items[i].amount);
            i++;
            //instantiatedPrefab.transform.SetParent(parentObject.transform);
            //instantiatedPrefab.transform.SetAsLastSibling();  
        }
    }
}