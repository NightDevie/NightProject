using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable
{
    public string UnitName;
    
    public UnitData UnitData;
    public UnitFaction UnitFaction;
    public UnitClass UnitClass;
     
    public int MaxHealth;
    public int CurrentHealth;
    public int Damage;
    public int UnitAmount;
    
    void Start()
    {
#if UNITY_EDITOR
        UpdateMyVariables();
        UnitData.OnValueChanged += UpdateMyVariables;
#endif
    }

#if UNITY_EDITOR
    void UpdateMyVariables()
    {
        MaxHealth = UnitData.getMaxHealth();
        CurrentHealth = MaxHealth;
        Damage = UnitData.getDamage();
        UnitName = UnitData.getUnitName();
    }
#endif

    public GameObject Selected()
    {
        return gameObject;
    }

    public void SetUnitData(UnitData unitData)
    {
        UnitData = unitData;
    }
    public void SetMaxHealth(int maxHealth)
    {
        MaxHealth = maxHealth;
    }
    public void SetCurrentHealth()
    {
        CurrentHealth = MaxHealth;
    }
    public void SetUnitAmount(int unitAmount)
    {
        UnitAmount = unitAmount;
    }
}