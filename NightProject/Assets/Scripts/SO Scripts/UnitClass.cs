using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New UnitClass", menuName = "UnitClass")]
public class UnitClass : ScriptableObject
{
    [SerializeField][FormerlySerializedAs("className")]
    public string className;

    [SerializeField][FormerlySerializedAs("StrongAgainstClasses")]
    public List<UnitClass> StrongAgainstClasses;
    
    [SerializeField][FormerlySerializedAs("WeakAgainstClasses")]
    public List<UnitClass> WeakAgainstClasses;
    
    [SerializeField][FormerlySerializedAs("NeutralAgainstClasses")]
    public List<UnitClass> NeutralAgainstClasses;
}