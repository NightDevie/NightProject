using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnit : MonoBehaviour
{
    public UnitsInventory unitsInventory;
    public GameObject unitPrefab;
    public GameObject parentObject;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => InstantiatePrefab(1));
    }

    public void InstantiatePrefab(int index)
    {
        GameObject instantiatedPrefab;
        instantiatedPrefab = Instantiate(unitPrefab, parentObject.transform);

        Unit unit = instantiatedPrefab.gameObject.GetComponent<Unit>();
        instantiatedPrefab.name = "[" + index + "]" + unit.unitName;
        Debug.Log("Instantiated");
    }
}