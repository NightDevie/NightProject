using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterFaction : MonoBehaviour
{
    public Inventory unitInventory;
    public GameObject unitPrefab;
    public GameObject parentObject;
    
    private GameObject instantiatedPrefab;
    private int n;
    
    public Button[] buttons;
    public string[] factionName;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            Debug.Log(i);
            buttons[i].onClick.AddListener(() => SpawnFactionCards(factionName[index]));
        }
    }

    private void OnValidate()
    {
        System.Array.Resize(ref factionName, buttons.Length);
    }

    public void SpawnFactionCards(string factionName)
    {
        n = 0;
        do
        {
            switch (factionName)
            {
                case "Faction1":
                    {
                        if (CheckClass("Class1", "Class2", "Class3") == true)
                        {
                            InstantiateUnitCards();
                        }
                        break;
                    }
                case "Faction2":
                    {
                        if (CheckClass("Class4", "Class5", "Class6") == true)
                        {
                            InstantiateUnitCards();
                        }
                        break;
                    }
                case "Faction3":
                    {
                        if (CheckClass("Class7", "Class8", "Class9") == true)
                        {
                            InstantiateUnitCards();
                        }
                        break;
                    }
            }
            n++;
        } while (n != unitInventory.Items.Count);
    }

    public void InstantiateUnitCards()
    {
        instantiatedPrefab = Instantiate(unitPrefab, parentObject.transform);
        instantiatedPrefab.name = "[" + n + "]" + unitInventory.Items[n].item.name;
        instantiatedPrefab.GetComponent<Unit>().setUnitData(unitInventory.Items[n].item);
        instantiatedPrefab.GetComponent<Unit>().setUnitAmount(unitInventory.Items[n].amount);
    }

    public bool CheckClass(string unitClass1, string unitClass2, string unitClass3)
    {
        if (unitInventory.Items[n].item.unitClass.ToString().Equals(unitClass1) |
            unitInventory.Items[n].item.unitClass.ToString().Equals(unitClass2) |
            unitInventory.Items[n].item.unitClass.ToString().Equals(unitClass3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}