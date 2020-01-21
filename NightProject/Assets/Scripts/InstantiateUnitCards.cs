using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnitCards : MonoBehaviour
{
    public UnitsInventory UnitInventory;
    public GameObject UnitPrefab;
    public GameObject ParentObject;
    
    private UnitFaction unitFaction;
    private GameObject instantiatedPrefab;
    
    public Button[] FactionButtons;
    public UnitFaction[] UnitFactions;

    void Start()
    {
        
    }
    
    public void AddListeners()
    {
        for (int i = 0; i < FactionButtons.Length; i++)
        {
            int factionIndex = i;
            FactionButtons[i].onClick.AddListener(() => CheckFaction(UnitFactions[factionIndex]));
        }
    }

    private void OnValidate()
    {
        System.Array.Resize(ref UnitFactions, FactionButtons.Length);
    }

    public void CheckFaction(UnitFaction unitFaction)
    {
        for (int i = 0; i < UnitInventory.Items.Count; i++)
        {
            if (unitFaction.CheckClass(UnitInventory.Items[i].Item.unitClass) == true)
            {
                InstantiatePrefabs(i);
            }
        }
    }

    public void InstantiatePrefabs(int i)
    {
        instantiatedPrefab = Instantiate(UnitPrefab, ParentObject.transform);
        instantiatedPrefab.name = "[" + i + "]" + UnitInventory.Items[i].Item.name;
        instantiatedPrefab.GetComponent<Unit>().setUnitData(UnitInventory.Items[i].Item);
        instantiatedPrefab.GetComponent<Unit>().setUnitAmount(UnitInventory.Items[i].Amount);
    }
}