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

    [SerializeField, FormerlySerializedAs("unitMaxHealth")]
    private int unitMaxHealth;

    [SerializeField, FormerlySerializedAs("unitDamage")]
    private int unitDamage;

    public string UnitName
    {
        get { return unitName; }
    }
    public UnitFaction UnitFaction
    {
        get { return unitFaction; }
    }
    public UnitClass UnitClass
    {
        get { return unitClass; }
    }
    public int UnitMaxHealth
    {
        get { return unitMaxHealth; }
    }
    public int UnitDamage
    {
        get { return unitDamage; }
    }

#if UNITY_EDITOR
    public event System.Action OnValueChanged;

    private void OnValidate()
    {
        OnValueChanged?.Invoke();
    }
#endif    
}