using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public sealed class CameraInput : MonoBehaviour
{
    /// <summary>The method used to find fingers to use with this component. See <see cref="LeanFingerFilter"/> documentation for more information.</summary>
    public LeanFingerFilter fingerFilter = new LeanFingerFilter(newIgnoreStartedOverGui: true);
    /// <summary>The method used to find world coordinates from a finger. See <see cref="LeanScreenDepth"/> documentation for more information.</summary>
    public LeanScreenDepth fingerWorldDepth = new LeanScreenDepth(newConversion: LeanScreenDepth.ConversionType.FixedDistance, newDistance: 30f);

    private Vector3 _touchWorldDelta;
    public Vector3 TouchWorldDelta
    {
        get
        {
            var touchWorldDeltaResult = _touchWorldDelta;
            _touchWorldDelta = Vector3.zero;
            return touchWorldDeltaResult;
        }
    }

    private void Awake()
    {
        fingerFilter.UpdateRequiredSelectable(gameObject: gameObject);
    }

    private void Update()
    {
        // Get the fingers we want to use
        List<LeanFinger> fingers = fingerFilter.UpdateAndGetFingers();

        //Vector2 screenDelta = LeanGesture.GetScreenDelta(fingers);

        // Get the last and current screen point of all fingers
        Vector2 lastScreenPoint = LeanGesture.GetLastScreenCenter(fingers);
        Vector2 screenPoint = LeanGesture.GetScreenCenter(fingers);

        // Convert this screenDelta into world space
        Vector3 worldDelta = fingerWorldDepth.ConvertDelta(lastScreenPoint: lastScreenPoint, screenPoint: screenPoint);

        // Accumulate
        _touchWorldDelta += worldDelta;
    }
}