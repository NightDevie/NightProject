using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitData : ScriptableObject
{
    public string unitName;
    
    public UnitFaction unitFaction;
    public UnitClass unitClass;
    
    public int maxHealth;
    public int damage;

#if UNITY_EDITOR
    public event System.Action OnValueChanged;

    private void OnValidate()
    {
        OnValueChanged?.Invoke();
    }
#endif    
}