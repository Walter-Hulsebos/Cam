namespace DefaultNamespace
{
    using UnityEngine;

    public sealed class AvoidRect : MonoBehaviour
    {
        [SerializeField] private RectTransform targetTransform;
        [SerializeField] private RectTransform avoidTransform;
        
        [SerializeField] private bool hor, ver;
    
        [ContextMenu("Avoid")]
        public void Avoid()
        {
            //rectTransformToClamp.ClampToRect(rectTransformToClampTo);
            targetTransform.EnsureRectOutside(avoidRectTransform: avoidTransform, moveHorizontally: hor, moveVertically: ver);
        }
    }
}