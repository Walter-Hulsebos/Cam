using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Lean.Gui;
using Lean.Touch;
using UnityEngine.UI;

public class RectConfinedMove : MonoBehaviour
{
    [SerializeField] RectTransform tooltipBorder;
    [SerializeField] RectTransform tooltip;
    //[SerializeField] RectTransform rectToAvoid;

    LeanSelectable selectable;
    [SerializeField] private Camera cameraMain;
    private void Start(){cameraMain = Camera.main;}
    private void Update()
    {
        var position = selectable.transform.position;
        if (position != null)
        {
            tooltip = RectMove.PlaceRectAtWorldPosition(rectTransform:
                tooltip, worldPosition: position, camera: cameraMain);
            tooltip = RectExtensions.Confine(tooltip, tooltipBorder);
        }
        //tooltip = RectExtensions.EnsureRectOutside(tooltip, rectToAvoid, true, true);
    }

    
}
