using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New UnitClass", menuName = "UnitClass")]
public class UnitClass : ScriptableObject
{
    [SerializeField][FormerlySerializedAs("unitName")]
    public string className;
}