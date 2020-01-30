using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnit : MonoBehaviour
{
    public UnitsInventory unitsInventory;
    public GameObject unitPrefab;
    public GameObject platformPrefab;
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
        GameObject instantiatedPlatformPrefab;
        GameObject instantiatedUnitPrefab;

        instantiatedPlatformPrefab = Instantiate(platformPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        instantiatedUnitPrefab = Instantiate(unitPrefab, instantiatedPlatformPrefab.transform);

        Unit unit = instantiatedUnitPrefab.gameObject.GetComponent<Unit>();
        instantiatedUnitPrefab.name = "[" + index + "]" + unit.unitName;
        Debug.Log("Instantiated");
    }
}