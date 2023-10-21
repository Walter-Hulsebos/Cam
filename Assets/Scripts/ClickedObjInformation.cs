using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]

public class ClickedObjInformation : MonoBehaviour
{

    // in general Camera.main is expensive -> rather store he reference and reuse it
    // Already reference this via the Inspector if possible
    [SerializeField] private Camera _mainCamera;
    Color lastUsedColor;

    private void Awake()
    {
        // as fallback get it ONCE on runtime
        if (!_mainCamera) _mainCamera = Camera.main;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                // Is what you clicked on a selectable?
                if (hit.transform.TryGetComponent<Selectable>(out var selectable))
                {
                    // Internally already handles deselection of current selected and skips if already selected this
                    selectable.Select();
                }
                // Optional: Deselect the current selection if you click on something else
                else
                {
                    Selectable.ClearSelection();
                }
            }
            // Optional: Deselect the current selection if you click on nothing
            else
            {
                Selectable.ClearSelection();
            }
        }
    }



}
