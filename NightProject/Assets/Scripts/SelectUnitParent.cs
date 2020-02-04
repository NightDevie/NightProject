using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitParent : MonoBehaviour, ISelectUnitParent
{
    public GameObject GetSelectedUnitParent
    {
        get { return gameObject; }
    }
}