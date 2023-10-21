using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Transition;
using Lean.Gui;
using Lean.Touch;

using LeanSelectable = Lean.Common.LeanSelectable;

public sealed class PositionSelectable : MonoBehaviour
{
    [SerializeField] private RectTransform targetToMove;
    
    [SerializeField] private RectTransform confines;
    
    [SerializeField] private Camera camera;
    
    //[SerializeField] private bool moveHorizontally, moveVertically;
    
    [SerializeField] private Vector2 offset;
    
    [SerializeField] private LeanSelectable selectable;

    private void Reset()
    {
        camera = Camera.main;
    }

    public void OnNewSelectable(LeanSelectable newSelectable)
    {
        selectable = newSelectable;
    }
    
    //[PublicAPI]
    private void Update()
    {
        if(selectable == null)
        {
            return;
        }
        
        //Debug.Log($"Moving to {selectable.name}");
    
        Vector3 __targetWorldPosition = selectable.transform.position;

        RectTransform __rectPosition = targetToMove.PlaceRectAtWorldPosition(worldPosition: __targetWorldPosition, camera: camera, canvasRect: confines);
    
        __rectPosition.anchoredPosition += offset;
        
        __rectPosition = __rectPosition.Confine(withinTransform: confines);

        targetToMove.anchoredPosition = __rectPosition.anchoredPosition;
    }
}
