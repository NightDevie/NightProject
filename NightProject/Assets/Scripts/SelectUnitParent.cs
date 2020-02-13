using UnityEngine;

public class SelectUnitParent : MonoBehaviour, ISelectUnitParent
{
    public GameObject GetSelectedUnitParent
    {
        get { return gameObject; }
    }
}