using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    private TouchControls controls;
    private Coroutine zoomCoroutine;
    //declaring camera variable
    private Camera mainCamera;
    [SerializeField]
    private float cameraSpeed=4f;
    [SerializeField]
    private float cameraZoomMin = 2f, cameraZoomMax = 6f, startingZoom=4f;

    private void Awake()
    {
        controls = new TouchControls();
    //storing reference to a camera
        mainCamera = Camera.main;
        mainCamera.orthographicSize = startingZoom;

    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Start()
    {
        controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Touch.SecondaryTouchContact.canceled += _ => ZoomEnd();
        

    }
    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);

    }
    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;
        
        while (true)
        {
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(),
                controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());
            //zoom in
            if (distance > previousDistance && mainCamera.orthographicSize>=cameraZoomMin)
            {
                float targetPosition = mainCamera.orthographicSize-cameraSpeed;
                
    
                mainCamera.orthographicSize =
                    Mathf.Lerp(mainCamera.orthographicSize, targetPosition, Time.deltaTime * cameraSpeed);

            }
            //zoom out
            else if(distance < previousDistance && mainCamera.orthographicSize <= cameraZoomMax)
            {
                float targetPosition = mainCamera.orthographicSize + cameraSpeed;
                //mainCamera.orthographicSize++;

                mainCamera.orthographicSize =
                    Mathf.Lerp(mainCamera.orthographicSize, targetPosition, Time.deltaTime * cameraSpeed);
            }

            previousDistance = distance;
            yield return null;
        }
    }
}
