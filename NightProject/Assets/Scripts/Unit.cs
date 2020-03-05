using UnityEngine;

public class Unit : MonoBehaviour, ISelectUnit
{
    [SerializeField] private new string name;
    [SerializeField] private UnitData unitData;
    [SerializeField] private UnitFaction unitFaction;
    [SerializeField] private UnitClass unitClass;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damage;

    [SerializeField] private int id;

    private int amount;


    void Start()
    {
#if UNITY_EDITOR
        UpdateUnitVariables();
        unitData.OnValueChanged += UpdateUnitVariables;
#endif
    }

#if UNITY_EDITOR
    public void OnValidate()
    {
        GetComponent<UnitUI>()?.EditorUnitUIUpdate();
        GetComponent<UnitCardUI>()?.EditorUnitCardUIUpdateAmount(Amount);
    }
    public void UpdateUnitVariables()
    {
        Name = unitData.Name;
        MaxHealth = unitData.MaxHealth;
        CurrentHealth = MaxHealth;
        Damage = unitData.Damage;
    }
#endif

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public GameObject GetSelectedUnit
    {
        get { return gameObject; }
    }
    public UnitData UnitData
    {
        get { return unitData; }
        set { unitData = value; }
    }
    public UnitFaction UnitFaction
    {
        get { return unitFaction; }
        set { unitFaction = value; }
    }
    public UnitClass UnitClass
    {
        get { return unitClass; }
        set { unitClass = value; }
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
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void DestroyParentObject()
    {
        Destroy(gameObject);
    }

    public void SetCurrentHealth()
    {
        currentHealth = maxHealth;
    }
}