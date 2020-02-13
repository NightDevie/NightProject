using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Unit unit;

    public Text nameText;
    public Text healthText;
    public Text damageText;
    public Text unitAmountText;

    public int amount;


    void Start()
    {
#if UNITY_EDITOR
       EditorUIUpdate();
       unit.unitData.OnValueChanged += EditorUIUpdate;
#endif
    }

#if UNITY_EDITOR
    public void EditorUIUpdate()
    {
        nameText.text = unit.name.ToString();
        healthText.text = unit.maxHealth.ToString();
        damageText.text = unit.damage.ToString();
        unitAmountText.text = unit.amount.ToString();
    }
#endif
}