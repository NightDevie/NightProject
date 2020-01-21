using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnit : MonoBehaviour
{
    public UnitsInventory UnitsInventory;
    public GameObject UnitPrefab;
    public GameObject ParentObject;
    public Button Button;

    private void Start()
    {
        Button.onClick.AddListener(() => InstantiatePrefab(1));
    }

    public void InstantiatePrefab(int index)
    {
        GameObject instantiatedPrefab;
        instantiatedPrefab = Instantiate(UnitPrefab, ParentObject.transform);

        Unit unit = instantiatedPrefab.gameObject.GetComponent<Unit>();
        instantiatedPrefab.name = "[" + index + "]" + unit.UnitName;
    }
}