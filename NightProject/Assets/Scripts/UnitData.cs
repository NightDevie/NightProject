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
    public Classes unitClass;
    public int maxHealth;
    public int damage;
    public enum Classes
    {
        Class1, Class2, Class3, Class4, Class5, Class7, Class8, Class9
    }

}