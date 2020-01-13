using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Items = new List<InventorySlot>();
    public void AddItem(UnitData item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].item == item)
            {
                Items[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Items.Add(new InventorySlot(item, amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public UnitData item;
    public int amount;
    public InventorySlot(UnitData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int amount)
    {
        this.amount += amount;
    }
}