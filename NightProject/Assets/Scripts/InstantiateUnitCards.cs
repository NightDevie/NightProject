using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnitCards : MonoBehaviour
{
    public UnitsInventory UnitsInventory;
    public GameObject UnitCardPrefab;
    public GameObject ParentObject;
    
    public Button[] FactionButtons;
    public UnitFaction[] UnitFactions;

    void Start()
    {
        AddListeners();
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
        for (int i = 0; i < UnitsInventory.Items.Count; i++)
        {
            if (unitFaction.CheckClass(UnitsInventory.Items[i].Item.getUnitClass()) == true)
            {
                InstantiatePrefab(i);
            }
        }
    }

    public void InstantiatePrefab(int index)
    {
        GameObject instantiatedPrefab;
        instantiatedPrefab = Instantiate(UnitCardPrefab, ParentObject.transform);
        
        Unit unit = instantiatedPrefab.gameObject.GetComponent<Unit>();
        unit.SetUnitData(UnitsInventory.Items[index].Item);
        unit.SetUnitAmount(UnitsInventory.Items[index].Amount);
        instantiatedPrefab.name = "[" + index + "]" + unit.UnitData.getUnitName();
    } 
}