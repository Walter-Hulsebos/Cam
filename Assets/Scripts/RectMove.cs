using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectMove 
{
    /// <summary>
    /// Places a rectTransform at a specified position based on a world-space object's UI position.
    /// </summary>
    public static RectTransform PlaceRectAtWorldPosition(this RectTransform rectTransform, Vector3 worldPosition, Camera camera)
    {
        Vector2 screenPoint = camera.WorldToScreenPoint(position: worldPosition);
        return rectTransform.PlaceRectAtScreenPosition(screenPosition: screenPoint);
    }

    /// <summary>
    /// Places a rectTransform at a specified position based on a screen-space position.
    /// </summary>
    public static RectTransform PlaceRectAtScreenPosition(this RectTransform rectTransform, Vector2 screenPosition)
    {
        // Convert the screen position to a Canvas position
        Vector2 canvasPosition = default;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect: rectTransform.parent as RectTransform,
            screenPoint: screenPosition,
            cam: null,
            localPoint: out canvasPosition
        );

        // Set the position and remove the anchor offsets
        rectTransform.anchoredPosition = canvasPosition - rectTransform.anchorMin * rectTransform.sizeDelta;

        return rectTransform;
    }
}
