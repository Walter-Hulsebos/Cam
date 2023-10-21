using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

[RequireComponent(typeof(CameraInput))]
public class PanCamera : MonoBehaviour
{


    #region Variables

    /// <summary>
    ///     The movement speed will be multiplied by this.
    ///     -1 = Inverted Controls.
    /// </summary>
    [SerializeField] private Single sensitivity = 1.0f;

    private Vector3 _targetPosition;

    private CameraInput _cameraInput;

    #endregion

    private void Awake()
    {
        _cameraInput = GetComponent<CameraInput>();
    }

    private void LateUpdate()
    {
        // Calculate _targetPosition based on accumulated touch delta, multiplied by sensitivity
        _targetPosition = transform.position - (_cameraInput.TouchWorldDelta * sensitivity);

        transform.position = _targetPosition;
    }


}

