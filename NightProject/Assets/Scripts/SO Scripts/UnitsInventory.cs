using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory")]
public class UnitsInventory : ScriptableObject //: MonoBehaviour
{
    public List<InventoryItem> Items = new List<InventoryItem>();

    public void AddItem(UnitData item, int amount)
    {
        Items.Add(new InventoryItem(item, amount));
    }

    public void RemoveItem(int index)
    {
        Items.RemoveAt(index);
    }

    public void AddAmount(UnitData item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Item == item)
            {
                Items[i].Amount += amount;
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            AddItem(item, amount);
        }
    }

    public void SubtractAmount(UnitData item, int amount)
    {
        for (int i = 0; i < Items.Count; i++)
        {  
            if (Items[i].Item == item)
            {
                if (Items[i].Amount > amount)
                {
                    Items[i].Amount -= amount;
                }
                else
                {
                    RemoveItem(i);
                }
                break;
            }
        }
    }
}

[System.Serializable]
public class InventoryItem
{
    public UnitData Item;
    public int Amount;
    public InventoryItem(UnitData item, int amount)
    {
        Item = item;
        Amount = amount;
    }
}