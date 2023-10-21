using System;
using UnityEngine;

public class SetBounds : MonoBehaviour
{
    private void Awake()
    {
        Bounds bounds = GetComponent<SpriteRenderer>().bounds;
        Globals.WorldBounds = bounds;
    }
}