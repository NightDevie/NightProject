using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterFaction : MonoBehaviour
{
    public Inventory unitInventory;
    public GameObject unitPrefab;
    private GameObject instantiatedPrefab;
    public GameObject parentObject;
    private int instanceNumber;
    int n;

    public void SpawnFactionCards(string factionName)
    {
        instanceNumber = 0;
        n = 0;
        do
        {
            switch (factionName)
            {
                case "Faction1":
                    {
                        if (CheckClass(n, "Class1", "Class2", "Class3") == true)
                        {
                            InstantiateUnitCards(n);
                        }
                        break;
                    }
                case "Faction2":
                    {
                        if (CheckClass(n, "Class4", "Class5", "Class6") == true)
                        {
                            InstantiateUnitCards(n);
                        }
                        break;
                    }
                case "Faction3":
                    {
                        if (CheckClass(n, "Class7", "Class8", "Class9") == true)
                        {
                            InstantiateUnitCards(n);
                        }
                        break;
                    }
            }
        } while (n != unitInventory.Items.Count);
    }

    public void InstantiateUnitCards(int n)
    {
        instantiatedPrefab = Instantiate(unitPrefab, parentObject.transform);
        instantiatedPrefab.name = "[" + instanceNumber + "]" + unitInventory.Items[n].item.name;
        instantiatedPrefab.GetComponent<Unit>().setUnitData(unitInventory.Items[n].item);
        instantiatedPrefab.GetComponent<Unit>().setUnitAmount(unitInventory.Items[n].amount);
        instanceNumber++;
        this.n++;
    }

    public bool CheckClass(int n, string class1, string class2, string class3)
    {
        if (unitInventory.Items[n].item.unitClass.ToString().Equals(class1) |
            unitInventory.Items[n].item.unitClass.ToString().Equals(class2) |
            unitInventory.Items[n].item.unitClass.ToString().Equals(class3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}