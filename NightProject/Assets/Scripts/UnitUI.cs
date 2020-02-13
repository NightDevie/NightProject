using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Unit unit;

    public Text nameText;
    public Text healthText;
    public Text damageText;


    void Start()
    {
#if UNITY_EDITOR
        EditorUnitUIUpdate();
        unit.UnitData.OnValueChanged += EditorUnitUIUpdate;
#endif
    }

#if UNITY_EDITOR
    public void EditorUnitUIUpdate()
    {
        nameText.text = unit.Name.ToString();
        healthText.text = unit.CurrentHealth.ToString();
        damageText.text = unit.Damage.ToString();
    }
#endif
}