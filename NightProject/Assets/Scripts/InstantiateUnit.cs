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
    private BattleManager battleManager;

    private void Awake()
    {
        battleManager = GameObject.Find("Player").GetComponent<BattleManager>();
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => InstantiatePrefab(1));
    }

    public void InstantiatePrefab(int index)
    {
        GameObject selectedPlatform;
        GameObject instantiatedUnitPrefab;

        Debug.Log(battleManager.selectedParent.name);
        selectedPlatform = battleManager.selectedParent;
        instantiatedUnitPrefab = Instantiate(unitPrefab, selectedPlatform.transform);

        Unit unit = instantiatedUnitPrefab.gameObject.GetComponent<Unit>();
        Unit cardUnit = GetComponent<Unit>();
        unit.SetUnitData(cardUnit.unitData);
        unit.SetUnitAmount(cardUnit.unitAmount);

        instantiatedUnitPrefab.name = "[" + index + "]" + unit.unitData.getUnitName();
        Debug.Log("Instantiated");
    }
}