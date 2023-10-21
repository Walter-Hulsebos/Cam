using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TransformCopier : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    
    [SerializeField] private Transform[] targetsToCopy;

    [ContextMenu("Copy Transforms")]
    private void CopyTransforms()
    {
        for (var index = 0; index < targetsToCopy.Length; index++)
        {
            var target = targetsToCopy[index];
            Transform newTransform = Instantiate(prefab, target.position, target.rotation);
            
            newTransform.name   = prefab.name + "." + index.ToString(format: "00");
            newTransform.parent = target.parent;
        }
    }
}
