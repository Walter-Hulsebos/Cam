using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class OldPanCamera : MonoBehaviour
{

    //Pan camera variable
    //1st script Vector3 touchStart;


    //2nd script bounds variables
    /* Vector3 origin;
     Vector3 difference;
     private Bounds cameraBounds;
     private Vector3 targetPosition;
     bool isDragging;


     //camera Variable(reference to the camera)
     private Camera mainCamera;

     private void Awake()
     {
         mainCamera = Camera.main;
     }
     public void OnDrag(InputAction.CallbackContext ctx)
     {
         if(ctx.started) origin= mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValueFromEvent<>());
         isDragging = ctx.started || ctx.performed;

     }

     private void Start()
     {
         var height = mainCamera.orthographicSize;
         var width = height * mainCamera.aspect;

         var minX = Globals.WorldBounds.min.x + width;
         var maxX = Globals.WorldBounds.extents.x - width;

         var minY = Globals.WorldBounds.min.y + height;
         var maxY = Globals.WorldBounds.extents.y - height;

         cameraBounds = new Bounds();
         cameraBounds.SetMinMax(new Vector3(minX, minY, 0.0f), new Vector3(maxX, maxY, 0.0f));
     }
     private void Update()
     {

         /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out RaycastHit hit))
         {
             Debug.DrawLine(transform.position, hit.point, Color.green);
             if (hit.collider.tag == "Boutique")
             {
                 if (Input.GetMouseButtonDown(0)) { NoRayPanningOldInput(); }
             }
         }*/
    //pan camera function
    //NoRayPanningOldInput();

    //pan camera function
    /*private void NoRayPanningOldInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;

        }
    }
    private void LateUpdate()
    {
        if (!isDragging) return;
        difference = GetMousePosition() - transform.position;
        targetPosition = GetCameraBounds();
        transform.position = origin - difference;


    }
    private Vector3 GetCameraBounds()
    {
        return new Vector3(Mathf.Clamp(targetPosition.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(targetPosition.y, cameraBounds.min.y, cameraBounds.max.y),
            transform.position.z);
    }
    private Vector3 GetMousePosition() => mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue<>());
    */
    /*
    #region Variables

    private Vector3 _origin;
    private Vector3 _difference;

    private Camera _mainCamera;

    private bool _isDragging;

    private Bounds _cameraBounds;
    private Vector3 _targetPosition;

    #endregion

    private void Awake() => _mainCamera = Camera.main;

    private void Start()
    {
        var height = _mainCamera.orthographicSize;
        var width = height * _mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
            );
    }


    private void LateUpdate()
    {
        /*
         * Note: Follow the tutorial here: https://youtu.be/CJWRx2qaakg
         * Whatever is following "transform.position" in your camera movement script,
         * set _targetPosition to that value.
         */

       /* _difference = GetMousePosition - transform.position;
        //_difference = GetTouchPosition - transform.position;


        _targetPosition = _origin - _difference;
        _targetPosition = GetCameraBounds();

        transform.position = _targetPosition;
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(_targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(_targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            transform.position.z
        );
    }

    private Vector3 GetMousePosition => _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    //private Vector3 GetTouchPosition => _mainCamera.ScreenToWorldPoint(Touchscreen.current.position.ReadValue());


    */

}

