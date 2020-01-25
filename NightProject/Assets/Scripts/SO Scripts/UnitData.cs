using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitData : ScriptableObject
{
    [SerializeField, FormerlySerializedAs("unitName")]
    private string unitName;

    [SerializeField, FormerlySerializedAs("unitFaction")]
    private UnitFaction unitFaction;

    [SerializeField, FormerlySerializedAs("unitClass")]
    private UnitClass unitClass;

    [SerializeField, FormerlySerializedAs("maxHealth")]
    private int maxHealth;

    [SerializeField, FormerlySerializedAs("damage")]
    private int unitDamage;

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
        return unitDamage;
    }

#if UNITY_EDITOR
    public event System.Action OnValueChanged;

    private void OnValidate()
    {
        OnValueChanged?.Invoke();
    }
#endif    
}