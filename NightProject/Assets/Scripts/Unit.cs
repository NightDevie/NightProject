using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectUnit
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
        maxHealth = unitData.getMaxHealth();
        currentHealth = maxHealth;
        damage = unitData.getDamage();
        unitName = unitData.getUnitName();
    }
#endif

    public GameObject GetSelectedUnit()
    {
        return gameObject;
    }

    public void SetUnitData(UnitData unitData)
    {
        this.unitData = unitData;
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public void SetCurrentHealth()
    {
        currentHealth = maxHealth;
    }
    public void SetUnitAmount(int unitAmount)
    {
        this.unitAmount = unitAmount;
    }
}