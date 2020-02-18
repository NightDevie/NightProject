using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnitCards : MonoBehaviour
{
    public UnitsInventory unitsInventory;
    public GameObject unitCardPrefab;
    public GameObject parentObject;
    
    public Button[] factionButtons;
    public UnitFaction[] unitFactions;

    private void OnValidate()
    {
        System.Array.Resize(ref unitFactions, factionButtons.Length);
    }

    public void CheckUnitFaction(UnitFaction unitFaction)
    {
        for (int i = 0; i < unitsInventory.Items.Count; i++)
        {
            if (unitFaction.CheckClass(unitsInventory.Items[i].Item.UnitClass) == true)
            {
                InstantiateUnitCardPrefab(i);
            }
        }
    }

    public void InstantiateUnitCardPrefab(int index)
    {
        GameObject instantiatedPrefab = Instantiate(unitCardPrefab, parentObject.transform);
        Unit unit = instantiatedPrefab.gameObject.GetComponent<Unit>();
        
        unit.UnitData = unitsInventory.Items[index].Item;
        unit.Amount = unitsInventory.Items[index].Amount;

        instantiatedPrefab.name = "[" + index + "]" + unit.UnitData.Name;
        instantiatedPrefab.GetComponent<UnitCardUI>().EditorUnitCardUIUpdate();
    }
}