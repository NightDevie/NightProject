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
}