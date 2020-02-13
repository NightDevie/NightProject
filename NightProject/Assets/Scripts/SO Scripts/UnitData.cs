using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitData : ScriptableObject
{
    [SerializeField, FormerlySerializedAs("unitName")]
    private new string name;

    [SerializeField, FormerlySerializedAs("unitFaction")]
    private UnitFaction unitFaction;

    [SerializeField, FormerlySerializedAs("unitClass")]
    private UnitClass unitClass;

    [SerializeField, FormerlySerializedAs("unitMaxHealth")]
    private int maxHealth;

    [SerializeField, FormerlySerializedAs("unitDamage")]
    private int damage;

    public string Name
    {
        get { return name; }
    }
    public UnitFaction UnitFaction
    {
        get { return unitFaction; }
    }
    public UnitClass UnitClass
    {
        get { return unitClass; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    public int Damage
    {
        get { return damage; }
    }

#if UNITY_EDITOR
    public event System.Action OnValueChanged;

    private void OnValidate()
    {
        OnValueChanged?.Invoke();
    }
#endif    
}