using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitData : ScriptableObject
{
    [SerializeField]
    private string unitName;
    [SerializeField]
    private UnitFaction unitFaction;
    [SerializeField]
    private UnitClass unitClass;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int damage;

    public string getUnitName()
    {
        return unitName;
    }

    public UnitFaction getUnitFaction()
    {
        return unitFaction;
    }

    public UnitClass getUnitClass()
    {
        return unitClass;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getDamage()
    {
        return damage;
    }

#if UNITY_EDITOR
    public event System.Action OnValueChanged;

    private void OnValidate()
    {
        OnValueChanged?.Invoke();
    }
#endif    
}