using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Unit unit;

    public Text unitText;
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
        unitText.text = unit.unitName.ToString();
        healthText.text = unit.maxHealth.ToString();
        damageText.text = unit.damage.ToString();
        unitAmountText.text = unit.unitAmount.ToString();
    }
#endif
}
