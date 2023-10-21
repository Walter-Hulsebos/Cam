using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoutiquesTextData", menuName = "ScriptableObjects/BoutiquesTextData", order = 1)]
public sealed class FlavorTextData : ScriptableObject
{
    [field:TextArea]
    [field:SerializeField] public String Text { get; private set; } 
}
