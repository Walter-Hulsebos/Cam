using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class RandomMeshColor : MonoBehaviour
{
    public List<Color> Colors;
    // Start is called before the first frame update
    void Start()
    {
        if (Colors.Count > 0)
        {
            Color c = Colors[Random.Range(0, Colors.Count)];
            GetComponent<Renderer>().material.color = c;
        }
    }
}