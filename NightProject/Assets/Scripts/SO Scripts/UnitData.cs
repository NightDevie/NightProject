using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitData : ScriptableObject
{
#if UNITY_EDITOR
    public event System.Action OnValueChanged;

    private void OnValidate()
    {
        OnValueChanged?.Invoke();
    }
#endif
    
    public string unitName;
    public int maxHealth;
    public int damage;
    public UnitFaction unitFaction;
    public UnitClass unitClass;
}