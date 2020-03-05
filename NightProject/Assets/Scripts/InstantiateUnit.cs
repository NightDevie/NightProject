using UnityEngine;
using UnityEngine.UI;

public class InstantiateUnit : MonoBehaviour
{
    public UnitsInventory unitsInventory;
    public GameObject unitPrefab;
    private BattleSystem battleSystem;
    private Selectable selectable;

    private void Awake()
    {
        battleSystem = GameObject.Find("Player").GetComponent<BattleSystem>();
    }

    private void Start()
    {
        Button button;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => InstantiateUnitPrefab(1));
    }

    public void InstantiateUnitPrefab(int index)
    {
        Unit cardUnit = GetComponent<Unit>();

        if (cardUnit.Amount > 0)
        {
            GameObject selectedPlatform;
            GameObject instantiatedUnitPrefab;

            selectedPlatform = battleSystem.selectedParent;
            instantiatedUnitPrefab = Instantiate(unitPrefab, selectedPlatform.transform);
            cardUnit.Amount --;

            Unit unit = instantiatedUnitPrefab.gameObject.GetComponent<Unit>();
            unit.UnitData = cardUnit.UnitData;
            unit.Amount = cardUnit.Amount;
            
            instantiatedUnitPrefab.name = "[" + index + "]" + unit.UnitData.Name;
#if UNITY_EDITOR
            instantiatedUnitPrefab.GetComponent<UnitUI>().EditorUnitUIUpdate();
#endif
            cardUnit.GetComponent<UnitCardUI>().unitAmountText.text = cardUnit.Amount.ToString();

            Debug.Log("Instantiated " + unit.UnitData.Name);
        }
    }
}