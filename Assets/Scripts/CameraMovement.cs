using System;
using JetBrains.Annotations;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /*#region Variables

    /// <summary>
    ///     The movement speed will be multiplied by this.
    ///     -1 = Inverted Controls.
    /// </summary>
    [SerializeField] private Single sensitivity = 1.0f;

    private Vector3 _origin;
    private Vector3 _touchWorldDelta;

    private Camera _mainCamera;

    private Boolean _isDragging;

    private Bounds _cameraBounds;
    private Vector3 _targetPosition;

    private Vector2 _previousTouchPosition; // Store the previous touch position

    #endregion

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        Single height = _mainCamera.orthographicSize;
        Single width = height * _mainCamera.aspect;

        Single minX = Globals.WorldBounds.min.x + width;
        Single maxX = Globals.WorldBounds.extents.x - width;

        Single minY = Globals.WorldBounds.min.y + height;
        Single maxY = Globals.WorldBounds.extents.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
                                min: new Vector3(x: minX, y: minY, z: 0.0f),
                                max: new Vector3(x: maxX, y: maxY, z: 0.0f)
                               );
    }

    private void LateUpdate()
    {
        // Calculate _targetPosition based on accumulated touch delta, multiplied by sensitivity
        _targetPosition = transform.position - (_touchWorldDelta * sensitivity);

        // Reset touch delta
        _touchWorldDelta = Vector3.zero;

        // Clamp _targetPosition to _cameraBounds
        _targetPosition = GetCameraBounds();

        transform.position = _targetPosition;
    }

    [UsedImplicitly]
    public void ReceiveTouchWorldDelta(Vector3 touchWorldDelta)
    {
        _touchWorldDelta += touchWorldDelta; // Accumulate touch delta
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
                           x: Mathf.Clamp(value: _targetPosition.x, min: _cameraBounds.min.x, max: _cameraBounds.max.x),
                           y: Mathf.Clamp(value: _targetPosition.y, min: _cameraBounds.min.y, max: _cameraBounds.max.y),
                           z: transform.position.z
                          );
    }*/
}
