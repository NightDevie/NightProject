using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Inventory unitInventory;
    public GameObject unitPrefab;
    public GameObject instantiatedPrefab;
    public GameObject parentObject;
    public GameObject selectedObject;
    private int instanceNumber;
    
    public void Start()
    {
        //SpawnObjects();
    }
    public void SpawnAllInventoryCards() //instantiatedPrefab.transform.SetParent(parentObject.transform); //instantiatedPrefab.transform.SetAsLastSibling();  
    {
        instanceNumber = 0;
        for (int i = 0; i < unitInventory.Items.Count; i++)
        {
            instantiatedPrefab = Instantiate(unitPrefab, parentObject.transform);
            instantiatedPrefab.name = "[" + instanceNumber + "]" + unitInventory.Items[i].item.name;
            instantiatedPrefab.GetComponent<Unit>().setUnitData(unitInventory.Items[i].item);
            instantiatedPrefab.GetComponent<Unit>().setUnitAmount(unitInventory.Items[i].amount);
            instanceNumber++;
        }
    }
}