using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectUnit
{
    public string unitName;
    
    public UnitData unitData;
    public UnitFaction unitFaction;
    public UnitClass unitClass;
     
    public int unitMaxHealth;
    public int unitCurrentHealth;
    public int unitDamage;
    public int unitAmount;
    
    void Start()
    {
#if UNITY_EDITOR
        UpdateUnitVariables();
        unitData.OnValueChanged += UpdateUnitVariables;
#endif
    }

#if UNITY_EDITOR
    void UpdateUnitVariables()
    {
        unitMaxHealth = unitData.UnitMaxHealth;
        unitCurrentHealth = unitMaxHealth;
        unitDamage = unitData.UnitDamage;
        unitName = unitData.UnitName;
    }
#endif

    public GameObject GetSelectedUnit
    {
        get { return gameObject; }
    }
    public UnitData UnitData
    {
        get { return unitData; }
        set { unitData = value; }
    }
    public int MaxHealth
    {
        get { return unitMaxHealth; }
        set { unitMaxHealth = value; }
    }
    public int UnitAmount
    {
        get { return unitAmount; }
        set { unitAmount = value; }
    }

    public void SetCurrentHealth()
    {
        unitCurrentHealth = unitMaxHealth;
    }
}