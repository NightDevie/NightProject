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
    private BattleSystem battleManager;

    private void Awake()
    {
        battleManager = GameObject.Find("Player").GetComponent<BattleSystem>();
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => InstantiateUnitPrefab(1));
    }

    public void InstantiateUnitPrefab(int index)
    {
        Unit cardUnit = GetComponent<Unit>();

        if (cardUnit.unitAmount > 0)
        {
            GameObject selectedPlatform;
            GameObject instantiatedUnitPrefab;

            selectedPlatform = battleManager.selectedParent;
            instantiatedUnitPrefab = Instantiate(unitPrefab, selectedPlatform.transform);

            Unit unit = instantiatedUnitPrefab.gameObject.GetComponent<Unit>();
            unit.unitData = cardUnit.unitData;
            unit.unitAmount = cardUnit.unitAmount;
            cardUnit.unitAmount --;
            
            instantiatedUnitPrefab.name = "[" + index + "]" + unit.unitData.UnitName;
            Debug.Log("Instantiated " + unit.unitData.UnitName);
        }
    }
}