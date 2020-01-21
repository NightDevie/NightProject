using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitFaction", menuName = "UnitFaction")]
public class UnitFaction : ScriptableObject
{
    public string FactionName;
    public List<UnitClass> FactionClasses;

    public bool CheckClass(UnitClass unitClass)
    {
        for (int i = 0; i < FactionClasses.Count; i++)
        {
            if (FactionClasses[i] == unitClass)
            {
                return true;
            }
        }
        return false;
    }
}