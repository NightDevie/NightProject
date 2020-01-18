using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterFaction : MonoBehaviour
{
    public Inventory unitInventory;
    public GameObject unitPrefab;
    public GameObject parentObject;
    
    private UnitFaction unitFaction;
    private GameObject instantiatedPrefab;
    
    public Button[] factionButtons;
    public UnitFaction[] unitFactions;

    void Start()
    {
        for (int i = 0; i < factionButtons.Length; i++)
        {
            int index = i;
            factionButtons[i].onClick.AddListener(() => SpawnFactionCards(unitFactions[index]));
        }
    }

    private void OnValidate()
    {
        System.Array.Resize(ref unitFactions, factionButtons.Length);
    }

    public void SpawnFactionCards(UnitFaction unitFaction)
    {
        for (int i = 0; i < unitInventory.Items.Count; i++)
        {
            if (unitFaction.CheckClass(unitInventory.Items[i].item.unitClass) == true)
            {
                InstantiateUnitCards(i);
            }
        }
    }

    public void InstantiateUnitCards(int i)
    {
        instantiatedPrefab = Instantiate(unitPrefab, parentObject.transform);
        instantiatedPrefab.name = "[" + i + "]" + unitInventory.Items[i].item.name;
        instantiatedPrefab.GetComponent<Unit>().setUnitData(unitInventory.Items[i].item);
        instantiatedPrefab.GetComponent<Unit>().setUnitAmount(unitInventory.Items[i].amount);
    }
}