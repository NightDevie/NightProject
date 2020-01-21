using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Unit Unit;

    public Text NameText;
    public Text HealthText;
    public Text DamageText;
    public Text UnitAmountText;

    public int Amount;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        editorUIUpdate();
        Unit.UnitData.OnValueChanged += editorUIUpdate;
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
        NameText.text = Unit.UnitName.ToString();
        HealthText.text = Unit.MaxHealth.ToString();
        DamageText.text = Unit.Damage.ToString();
        UnitAmountText.text = Unit.UnitAmount.ToString();
    }
#endif
}