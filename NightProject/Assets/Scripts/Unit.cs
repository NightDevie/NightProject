using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unitData;
    public UnitUI unitUI;
    public string unitName;
    public int maxHealth;
    public int currentHealth;
    public int damage;

    public void setUnitData(UnitData unitData)
    {
        
        this.unitData = unitData;
    }

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
}