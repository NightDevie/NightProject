using UnityEngine;
public class BattleSystem : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedAlliedUnit;
    [HideInInspector]
    public GameObject selectedParent;

    public Camera mainCamera;
    public InstantiateUnitCards instantiateUnitCards;
    public GameObject alliedUnitPlatforms;
    public GameObject enemyUnitPlatforms;
    public GameObject startFight;
    public GameObject unitCards;

    private State state;

    private void Start()
    {
        state = new StartState();
        state.battleSystem = this;
        state?.OnStateEnter();
    }

    private void Update()
    {
        state?.Update();
    }

    public void SwitchState(State newState)
    {
        state?.OnStateExit();
        state = newState;
        state.battleSystem = this;
        state?.OnStateEnter();
    }

    public void Attack(Unit attacker, Unit defender)
    {
        Debug.Log("Defender " + defender.Name + " CurrentHealth: " + defender.CurrentHealth);

        defender.TakeDamage(attacker.Damage);
        defender.gameObject.GetComponent<UnitUI>().EditorUnitUIUpdate();

        Debug.Log(attacker.Name + " dealt " + attacker.Damage.ToString() + " to " + defender.Name);
        Debug.Log("Defender " + defender.Name + " CurrentHealth: " + defender.CurrentHealth);
    }
    
    public void CalculateDamage(Unit attacker, Unit defender)
    {

    }

    /*public int ClassDamageMultiplier(Unit attacker, Unit defender)
    {
        switch (attacker.UnitFaction.factionName)
        {
            case "Faction1":

            break;

            case "Faction2":

            break;

            case "Faction3":

            break;
        }
    }*/
}