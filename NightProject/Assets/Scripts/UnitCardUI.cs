using UnityEngine;
using UnityEngine.UI;

public class UnitCardUI : MonoBehaviour
{
    public Unit unit;

    public Text nameText;
    public Text healthText;
    public Text damageText;
    public Text unitAmountText;

    void Start()
    {
#if UNITY_EDITOR
        EditorUnitCardUIUpdate();
        unit.UnitData.OnValueChanged += EditorUnitCardUIUpdate;
#endif
    }

#if UNITY_EDITOR
    public void EditorUnitCardUIUpdateAmount(int amount)
    {
        unitAmountText.text = amount.ToString();
    }
    public void EditorUnitCardUIUpdate()
    {
        nameText.text = unit.UnitData.Name.ToString();
        healthText.text = unit.UnitData.MaxHealth.ToString();
        damageText.text = unit.UnitData.Damage.ToString();
        unitAmountText.text = unit.Amount.ToString();
    }
#endif
}
