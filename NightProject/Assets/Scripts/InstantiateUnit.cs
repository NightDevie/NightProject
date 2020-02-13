using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnit : MonoBehaviour
{
    public UnitsInventory unitsInventory;
    public GameObject unitPrefab;
    public GameObject parentPrefab;
    public GameObject parentObject;
    private Button button;
    private BattleSystem battleSystem;

    private void Awake()
    {
        battleSystem = GameObject.Find("Player").GetComponent<BattleSystem>();
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => InstantiateUnitPrefab(1));
    }

    public void InstantiateUnitPrefab(int index)
    {
        Unit cardUnit = GetComponent<Unit>();

        if (cardUnit.amount > 0)
        {
            GameObject selectedPlatform;
            GameObject instantiatedUnitPrefab;

            selectedPlatform = battleSystem.selectedParent;
            instantiatedUnitPrefab = Instantiate(unitPrefab, selectedPlatform.transform);
            cardUnit.Amount --;

            Unit unit = instantiatedUnitPrefab.gameObject.GetComponent<Unit>();
            unit.unitData = cardUnit.unitData;
            unit.amount = cardUnit.amount;
            
            instantiatedUnitPrefab.name = "[" + index + "]" + unit.unitData.UnitName;

            cardUnit.UpdateUnitVariables();
            cardUnit.GetComponent<UnitUI>().EditorUIUpdate();
           // unit.UpdateUnitVariables();
           // unit.GetComponent<UnitUI>().EditorUIUpdate();

            Debug.Log("Instantiated " + unit.unitData.UnitName);
        }
    }
}