using UnityEngine;

public sealed class ConfineToRect : MonoBehaviour
{
    [SerializeField] private RectTransform targetToClamp;
    [SerializeField] private RectTransform confines;
    
    [ContextMenu("Clamp")]
    public void Clamp()
    {
        targetToClamp.Confine(withinTransform: confines);
    }
}
