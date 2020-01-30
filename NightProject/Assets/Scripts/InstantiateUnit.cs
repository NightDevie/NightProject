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

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => InstantiatePrefab(1));
    }

    public void InstantiatePrefab(int index)
    {
        GameObject selectedPlatform;
        GameObject instantiatedUnitPrefab;

        selectedPlatform = Instantiate(parentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        instantiatedUnitPrefab = Instantiate(unitPrefab, selectedPlatform.transform);

        Unit unit = instantiatedUnitPrefab.gameObject.GetComponent<Unit>();
        instantiatedUnitPrefab.name = "[" + index + "]" + unit.unitName;
        Debug.Log("Instantiated");
    }
}