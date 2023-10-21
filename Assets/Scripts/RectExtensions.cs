using System.Collections.Generic;

using Unity.Mathematics;

using UnityEngine;

using static UnityEngine.Mathf;

public static class RectExtensions
{
    /// <summary>
    /// Makes a rect stay within the boundaries of another rect.
    /// The rectToLimit's position will be modified to fit within the limits as best as possible, its size will not be modified.
    /// </summary>
    public static RectTransform Confine(this RectTransform rectToLimit, RectTransform withinTransform)
    {
        // Calculate the boundaries of the limits rect
        Rect __withinRect = new Rect(
            x: withinTransform.rect.xMin + withinTransform.anchoredPosition.x,
            y: withinTransform.rect.yMin + withinTransform.anchoredPosition.y,
            width: withinTransform.rect.width,
            height: withinTransform.rect.height
        );
        
        //Rect __withinRect = withinTransform.rect;
        
        return rectToLimit.Confine(limits: __withinRect);
    }

    public static RectTransform Confine(this RectTransform rectToLimit, Rect limits)
    {
        // Calculate the boundaries of the rectToLimit
        Rect __rectToLimitRect = new Rect(
            x: rectToLimit.rect.xMin + rectToLimit.anchoredPosition.x,
            y: rectToLimit.rect.yMin + rectToLimit.anchoredPosition.y,
            width: rectToLimit.rect.width,
            height: rectToLimit.rect.height
        );
        
        //Rect __rectToLimitRect = rectToLimit.rect;

        // Calculate the new X and Y positions for rectToLimit
        float newX = rectToLimit.anchoredPosition.x;
        float newY = rectToLimit.anchoredPosition.y;

        // Check if rectToLimit's left edge is outside the left limit
        if (__rectToLimitRect.xMin < limits.xMin)
        {
            // Move rectToLimit to the right to align with the left limit
            newX += limits.xMin - __rectToLimitRect.xMin;
        }
        // Check if rectToLimit's right edge is outside the right limit
        else if (__rectToLimitRect.xMax > limits.xMax)
        {
            // Move rectToLimit to the left to align with the right limit
            newX -= __rectToLimitRect.xMax - limits.xMax;
        }

        // Check if rectToLimit's bottom edge is below the bottom limit
        if (__rectToLimitRect.yMin < limits.yMin)
        {
            // Move rectToLimit upwards to align with the bottom limit
            newY += limits.yMin - __rectToLimitRect.yMin;
        }
        // Check if rectToLimit's top edge is above the top limit
        else if (__rectToLimitRect.yMax > limits.yMax)
        {
            // Move rectToLimit downwards to align with the top limit
            newY -= __rectToLimitRect.yMax - limits.yMax;
        }

        // Update the rectToLimit's anchored position to keep it within the limits
        rectToLimit.anchoredPosition = new Vector2(x: newX, y: newY);
        
        return rectToLimit;
    }
    
    /// <summary>
    /// Ensures that a RectTransform stays outside of a specified Rect to avoid overlapping.
    /// The target's position will be modified to stay outside the avoidRect as needed.
    /// </summary>
    public static RectTransform EnsureRectOutside(this RectTransform target, RectTransform avoidRectTransform, bool moveHorizontally = true, bool moveVertically = true)
    {
        Rect __avoidRect = new Rect(
            x: avoidRectTransform.rect.xMin + avoidRectTransform.anchoredPosition.x,
            y: avoidRectTransform.rect.yMin + avoidRectTransform.anchoredPosition.y,
            width: avoidRectTransform.rect.width,
            height: avoidRectTransform.rect.height
        );

        return target.EnsureRectOutside(avoidRect: __avoidRect, moveHorizontally: moveHorizontally, moveVertically: moveVertically);
    }
    
    /// <summary>
    /// Ensures that a RectTransform stays outside of a specified Rect to avoid overlapping.
    /// The target's position will be modified to stay outside the avoidRect as needed.
    /// </summary>
    public static RectTransform EnsureRectOutside(this RectTransform target, Rect avoidRect, bool moveHorizontally = true, bool moveVertically = true)
    {
        // Calculate the boundaries of the target RectTransform
        Rect targetRect = new Rect(
            x: target.rect.xMin + target.anchoredPosition.x,
            y: target.rect.yMin + target.anchoredPosition.y,
            width: target.rect.width,
            height: target.rect.height
        );

        float newX = target.anchoredPosition.x;
        float newY = target.anchoredPosition.y;

        if (moveHorizontally)
        {
            if (targetRect.xMax > avoidRect.xMin && targetRect.xMin < avoidRect.xMax)
            {
                // There is a horizontal overlap; adjust the position
                if (targetRect.center.x < avoidRect.center.x)
                {
                    // Move to the left
                    newX = avoidRect.xMin - targetRect.width / 2;
                }
                else
                {
                    // Move to the right
                    newX = avoidRect.xMax + targetRect.width / 2;
                }
            }
        }

        if (moveVertically)
        {
            if (targetRect.yMax > avoidRect.yMin && targetRect.yMin < avoidRect.yMax)
            {
                // There is a vertical overlap; adjust the position
                if (targetRect.center.y < avoidRect.center.y)
                {
                    // Move upwards
                    newY = avoidRect.yMin - targetRect.height / 2;
                }
                else
                {
                    // Move downwards
                    newY = avoidRect.yMax + targetRect.height / 2;
                }
            }
        }

        // Update the target's anchored position
        target.anchoredPosition = new Vector2(x: newX, y: newY);

        return target;
    }
    
    /// <summary>
    /// Places a rectTransform at a specified position based on a world-space object's UI position.
    /// </summary>
    public static RectTransform PlaceRectAtWorldPosition(this RectTransform rectTransform, Vector3 worldPosition, Camera camera, RectTransform canvasRect)
    {
        //Debug.Log("Camera: " + camera);
        
        //Debug.Log("World position: " + worldPosition);
        
        Vector3 __viewportPoint = camera.WorldToViewportPoint(worldPosition);
        
        //__parentRectTransform.rect.width  *= __parentRectTransform.lossyScale.x;
        
        // Calculate the size of the canvas in world units
        float __canvasWidth  = canvasRect.rect.width;
        float __canvasHeight = canvasRect.rect.height;

        // Calculate the UI position by scaling the viewport point to match the canvas size
        Vector2 __uiPosition = new Vector2((__viewportPoint.x - 0.5f) * __canvasWidth, (__viewportPoint.y - 0.5f) * __canvasHeight);
        
        //Debug.Log("Viewport point: " + __viewportPoint);

        // Set the position and remove the anchor offsets
        rectTransform.anchoredPosition = __uiPosition;  

        return rectTransform;
    }
    
    public static RectTransform PlaceRectAtWorldPosition(this RectTransform rectTransform, Vector3 worldPosition, Camera camera, Canvas canvas)
    {
        Vector2 __screenPoint = (Vector2)camera.WorldToScreenPoint(position: worldPosition);

        // Convert the world position to canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect: canvas.transform as RectTransform, screenPoint: __screenPoint, cam: camera, localPoint: out Vector2 __canvasPosition);

        // Set the anchored position of the RectTransform
        rectTransform.anchoredPosition = __canvasPosition;

        return rectTransform;
    }
    
    /// <summary>
    /// Places a rectTransform at a specified position based on a screen-space position.
    /// </summary>
    public static RectTransform PlaceRectAtScreenPosition(this RectTransform rectTransform, Vector2 screenPosition, Camera camera)
    {
        // Convert the screen position to a Canvas position
        Vector2 canvasPosition = default;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect: rectTransform.parent as RectTransform,
            screenPoint: screenPosition,
            cam: camera,
            localPoint: out canvasPosition
        );

        // Set the position and remove the anchor offsets
        rectTransform.anchoredPosition = canvasPosition - rectTransform.anchorMin * rectTransform.sizeDelta;

        return rectTransform;
    }
    
    // public static RectTransform EvaluateBestPosition(this RectTransform rectTransform, Vector2 screenPosition, Camera camera, RectTransform withinTransform)
    // {
    //     // Convert the screen position to a Canvas position
    //     Vector2 canvasPosition = default;
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //         rect: rectTransform.parent as RectTransform,
    //         screenPoint: screenPosition,
    //         cam: null,
    //         localPoint: out canvasPosition
    //     );
    //
    //     // Set the position and remove the anchor offsets
    //     rectTransform.anchoredPosition = canvasPosition - rectTransform.anchorMin * rectTransform.sizeDelta;
    //
    //     return rectTransform;
    // }
    
    /// <summary>
    /// Evaluates the best position for a RectTransform based on specified limits and areas to avoid.
    /// </summary>
    /// <param name="target">The RectTransform to position.</param>
    /// <param name="limits">The RectTransform representing the limits.</param>
    /// <param name="avoidAreas">An array of Rect areas to avoid.</param>
    /// <returns>The best position for the target RectTransform.</returns>
    public static Vector2 EvaluateBestPosition(this RectTransform target, RectTransform limits, Rect[] avoidAreas)
    {
        // Calculate the boundaries of the target RectTransform
        Rect targetRect = new Rect(
            x: target.rect.xMin + target.anchoredPosition.x,
            y: target.rect.yMin + target.anchoredPosition.y,
            width: target.rect.width,
            height: target.rect.height
        );

        // Calculate the boundaries of the limits RectTransform
        Rect limitsRect = new Rect(
            x: limits.rect.xMin + limits.anchoredPosition.x,
            y: limits.rect.yMin + limits.anchoredPosition.y,
            width: limits.rect.width,
            height: limits.rect.height
        );

        // Initialize a list to store valid positions
        List<Vector2> validPositions = new List<Vector2>();

        // Iterate through the possible positions within the limits
        for (float x = limitsRect.xMin; x <= limitsRect.xMax - targetRect.width; x++)
        {
            for (float y = limitsRect.yMin; y <= limitsRect.yMax - targetRect.height; y++)
            {
                Vector2 newPosition = new Vector2(x: x - targetRect.xMin, y: y - targetRect.yMin);

                // Check if the new position overlaps with any avoid area
                bool overlapsAvoidArea = false;
                foreach (Rect avoidArea in avoidAreas)
                {
                    if (newPosition.x + targetRect.width >= avoidArea.xMin &&
                        newPosition.x <= avoidArea.xMax &&
                        newPosition.y + targetRect.height >= avoidArea.yMin &&
                        newPosition.y <= avoidArea.yMax)
                    {
                        overlapsAvoidArea = true;
                        break;
                    }
                }

                // If the new position doesn't overlap with any avoid area, add it to the list of valid positions
                if (!overlapsAvoidArea)
                {
                    validPositions.Add(item: newPosition);
                }
            }
        }

        // Find the best position among the valid positions (you can implement a custom logic here)
        Vector2 bestPosition = Vector2.zero;
        float bestScore = float.MaxValue;

        foreach (Vector2 validPosition in validPositions)
        {
            // You can implement a scoring function to evaluate positions based on your criteria
            // For now, let's assume the position with the least distance from the center of limits is the best
            float score = Vector2.Distance(a: validPosition + targetRect.center, b: limitsRect.center);

            if (score < bestScore)
            {
                bestScore = score;
                bestPosition = validPosition;
            }
        }

        return bestPosition;
    }

}
