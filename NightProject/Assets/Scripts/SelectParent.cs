using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParent : MonoBehaviour, ISelectParent
{
    public GameObject GetSelectedParent()
    {
        return gameObject;
    }
}