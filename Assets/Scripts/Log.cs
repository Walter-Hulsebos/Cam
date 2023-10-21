using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Log : MonoBehaviour
{
    public void DebugLog(string message) => Debug.Log(message);
}
