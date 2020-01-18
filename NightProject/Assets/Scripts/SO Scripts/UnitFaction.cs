using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitFaction", menuName = "UnitFaction")]
public class UnitFaction : ScriptableObject
{
    public string factionName;
    public List<UnitClass> factionClasses;

    public bool CheckClass(UnitClass unitClass)
    {
        for (int i = 0; i < factionClasses.Count; i++)
        {
            if (factionClasses[i] == unitClass)
            {
                return true;
            }
        }
        return false;
    }
}