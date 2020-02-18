using UnityEngine;

public class SelectUnitParent : MonoBehaviour, ISelectUnitParent
{
    private BattleSystem battleSystem;
    private SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();

    private void Start()
    {
        battleSystem = GameObject.Find("Player").GetComponent<BattleSystem>();
    }
    
    public GameObject GetSelectedUnitParent
    {
        get { return gameObject; }
    }

    private void OnMouseEnter()
    {
        if(gameObject != battleSystem.selectedParent)
        {
            SpriteRenderer.color = new Color(0.80f, 0.80f, 0.80f);
        }
    }

    private void OnMouseDown()
    {
        if (battleSystem.selectedParent != gameObject)
        {
            if(battleSystem.selectedParent != null)
            {
                battleSystem.selectedParent.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                SpriteRenderer.color = new Color(0.60f, 0.60f, 0.60f);
            }
        }
    }

    private void OnMouseExit()
    {
        if (battleSystem.selectedParent != gameObject)
        {
            SpriteRenderer.color = new Color(1f, 1f, 1f);
        }
    }
}