using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlavorTextData", menuName = "ScriptableObjects/BoutiquesTextData", order = 1)]
public class BoutiquesTextData : ScriptableObject
{
    
    //[field: SerializeField] public String Title { get; private set; }
    [field: TextArea]
    [field: SerializeField] public String Text { get; private set; }
    
    

}
