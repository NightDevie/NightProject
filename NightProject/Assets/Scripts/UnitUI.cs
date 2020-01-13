using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public Unit unit;
    public static UnitUI unitUI;

    public Text unitText;
    public Text healthText;
    public Text damageText;
    
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        UpdateUI();
        unit.unitData.OnValueChanged += UpdateUI;
#endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int health)
    {
        
    }
#if UNITY_EDITOR
    public void UpdateUI()
    {
        unitText.text = unit.unitName.ToString();
        healthText.text = unit.maxHealth.ToString();
        damageText.text = unit.damage.ToString();
    }
#endif
}
