using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectUnit
{
    public new string name;
    
    public UnitData unitData;
    public UnitFaction unitFaction;
    public UnitClass unitClass;
     
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int amount;
    public int id;
    
    void Start()
    {
#if UNITY_EDITOR
        UpdateUnitVariables();
        unitData.OnValueChanged += UpdateUnitVariables;
#endif
    }

#if UNITY_EDITOR
    public void UpdateUnitVariables()
    {
        MaxHealth = unitData.UnitMaxHealth;
        CurrentHealth = maxHealth;
        Damage = unitData.UnitDamage;
        name = unitData.UnitName;
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
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public void SetCurrentHealth()
    {
        currentHealth = maxHealth;
    }
}