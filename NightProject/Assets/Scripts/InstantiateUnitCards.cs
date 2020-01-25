using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnitCards : MonoBehaviour
{
    public UnitsInventory unitsInventory;
    public GameObject unitCardPrefab;
    public GameObject parentObject;
    
    public Button[] factionButtons;
    public UnitFaction[] unitFactions;

    void Start()
    {
        AddListeners();
    }
    
    public void AddListeners()
    {
        for (int i = 0; i < factionButtons.Length; i++)
        {
            int factionIndex = i;
            factionButtons[i].onClick.AddListener(() => CheckFaction(unitFactions[factionIndex]));
        }
    }

    private void OnValidate()
    {
        System.Array.Resize(ref unitFactions, factionButtons.Length);
    }

    public void CheckFaction(UnitFaction unitFaction)
    {
        for (int i = 0; i < unitsInventory.Items.Count; i++)
        {
            if (unitFaction.CheckClass(unitsInventory.Items[i].Item.getUnitClass()) == true)
            {
                InstantiatePrefab(i);
            }
        }
    }

    public void InstantiatePrefab(int index)
    {
        GameObject instantiatedPrefab;
        instantiatedPrefab = Instantiate(unitCardPrefab, parentObject.transform);
        
        Unit unit = instantiatedPrefab.gameObject.GetComponent<Unit>();
        unit.SetUnitData(unitsInventory.Items[index].Item);
        unit.SetUnitAmount(unitsInventory.Items[index].Amount);
        instantiatedPrefab.name = "[" + index + "]" + unit.unitData.getUnitName();
    } 
}