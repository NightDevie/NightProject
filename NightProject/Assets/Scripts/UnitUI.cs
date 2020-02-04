﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        editorUIUpdate();
        unit.unitData.OnValueChanged += editorUIUpdate;
#endif
    }

    public void UIUpdateUnitHealth()
    {

    }

    public void UIUpdateUnitAmount()
    {
        
    }

#if UNITY_EDITOR
    public void editorUIUpdate()
    {
        nameText.text = unit.unitName.ToString();
        healthText.text = unit.unitMaxHealth.ToString();
        damageText.text = unit.unitDamage.ToString();
        unitAmountText.text = unit.unitAmount.ToString();
    }
#endif
}