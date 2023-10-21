using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsManager : MonoBehaviour
{
    #region Evemts
    private delegate void StartTouch(Vector2 position, float time);
    private event StartTouch OnStartTouch;
    private delegate void EndTouch(Vector2 position, float time);
    private event EndTouch OnEndTouch;

    private delegate void Tapped();
    private event Tapped OnTapped;
    private delegate void MultiTapped();
    private event MultiTapped OnMultiTapped;

    private delegate void LeftSwipe();
    private event LeftSwipe OnSwipeLeft;
    private delegate void RightSwipe();
    private event RightSwipe OnSwipeRight;
    private delegate void UpSwipe();
    private event UpSwipe OnSwipeUp;
    private delegate void DownSwipe();
    private event DownSwipe OnSwipeDown;
    #endregion
    [SerializeField] private float minDistance = 15f;
    [SerializeField] private float maxTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = 0.9f;

    private Vector2 startPosition, endPosition;
    private float startTime, endTime;
    private TouchControls controls;

    private void Awake()=>controls = new TouchControls();

    private void OnEnable()
    {
        controls.Enable();
        OnStartTouch += SwipeStart;
        OnEndTouch += SwipeEnd;
    }
    private void OnDisable()
    {
        controls.Disable();
        OnStartTouch -= SwipeStart;
        OnEndTouch -= SwipeEnd;
    }
    private void Start()
    {
        controls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        controls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        controls.Touch.Tap.performed += ctx => TappedPerformed(ctx);
        controls.Touch.MultiTap.performed += ctx => MultiTappedPerformed(ctx);


    }

    private void TappedPerformed(InputAction.CallbackContext ctx){if (OnTapped != null){OnTapped();}}
    private void MultiTappedPerformed(InputAction.CallbackContext ctx) { if (OnMultiTapped != null) { OnMultiTapped(); } }
    private void StartTouchPrimary(InputAction.CallbackContext ctx){if (OnStartTouch != null){OnStartTouch(ScreenPosition(), (float)ctx.startTime);}}
    private void EndTouchPrimary(InputAction.CallbackContext ctx) { if (OnEndTouch != null) { OnEndTouch(ScreenPosition(), (float)ctx.time); } }

    private Vector2 ScreenPosition() { return controls.Touch.PrimaryPosition.ReadValue<Vector2>(); }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;

    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        //Swipe detection
        DetectSwipe();

    }

    private void DetectSwipe()
    {
        if(Vector3.Distance(startPosition, endPosition) >= minDistance && (endTime-startTime)<maxTime)
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            //swipe direction
            SwipeDirection(direction2D);



        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            if (OnSwipeUp != null) OnSwipeUp();
        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            if (OnSwipeDown != null) OnSwipeDown();
        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            if (OnSwipeLeft != null) OnSwipeLeft();
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            if (OnSwipeRight != null) OnSwipeRight();
        }
    }
}
