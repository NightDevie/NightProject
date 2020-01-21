using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    
    public UnitData unitData;
    public UnitFaction unitFaction;
    public UnitClass unitClass;
     
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int unitAmount;
    

    void Start()
    {
#if UNITY_EDITOR
        UpdateMyVariables();
        unitData.OnValueChanged += UpdateMyVariables;
#endif
    }

#if UNITY_EDITOR
    void UpdateMyVariables()
    {
        maxHealth = unitData.maxHealth;
        currentHealth = maxHealth;
        damage = unitData.damage;
        unitName = unitData.unitName;
    }
#endif

    public void setUnitData(UnitData unitData)
    {
        this.unitData = unitData;
    }

    public void setMaxHealth(int maxHealth)
    {

    }
    public void setCurrentHealth()
    {
        currentHealth = maxHealth;
    }
    public void setUnitAmount(int unitAmount)
    {
        this.unitAmount = unitAmount;
    }
}