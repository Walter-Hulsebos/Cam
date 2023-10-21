using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private BillboardType billboardType;

    //added variable from Samyam discord channel from help script
    // The position offset from the parent.
    [SerializeField] private Vector3 offsetFromParent;
    [SerializeField] private Transform parent;

    [Header("Lock Rotation")]
    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;

    private Vector3 originalRotation;

    public enum BillboardType { LookAtCamera, CameraForward };

    private void Awake()
    {
        originalRotation = -transform.rotation.eulerAngles;
        transform.position = parent.position + offsetFromParent;
    }

    // Use Late update so everything should have finished moving.
    void LateUpdate()
    {
        // There are two ways people billboard things.
        switch (billboardType)
        {
            case BillboardType.LookAtCamera:
                transform.LookAt(Camera.main.transform.position, Vector3.up);
                break;
            case BillboardType.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            default:
                break;
        }
        // Modify the rotation in Euler space to lock certain dimensions.
        Vector3 rotation = transform.rotation.eulerAngles;
        if (lockX) { rotation.x = originalRotation.x; }
        if (lockY) { rotation.y = originalRotation.y; }
        if (lockZ) { rotation.z = originalRotation.z; }
        transform.rotation = Quaternion.Euler(rotation);
    }



    //Samyam Discord chanel answer
    // The target to look at.
    /*[SerializeField] private Transform target;
    
    // The parent of this object.
    [SerializeField] private Transform parent;
    
    // The position offset from the parent.
    [SerializeField] private Vector3 offsetFromParent;
    
    // The rotation offset from the target.
    [SerializeField] private Vector3 offsetRotation;

    [SerializeField] private FacingCamera facingCamera; 

    // Get the position of the target, but with the y value of this object.
    private Vector3 FlatTargetPosition => new Vector3(target.position.x, transform.position.y, target.position.z);

	
    // Called when the script is loaded (Called in the editor only).
	// Finding the target in here ensures that we'll have a reference to the camera immediately when the script is added.
    private void Reset()
    {
        FindTarget();
    }
    
    // Called when a value is changed in the inspector (Called in the editor only).
    private void OnValidate()
    {
        // Set the local position, if the game is playing.
        if (Application.isPlaying)
        {
            transform.position = parent.position + offsetFromParent;
        }

        // If target is null, find the main camera.
        if (target == null)
        {
            FindTarget();
        }
    }
    
    // Find the main camera and set it as the target.
    private void FindTarget()
    {
        target = Camera.main.transform;
    }
    
    private void Start()
    {
        // Set the parent and local position.
        transform.position = parent.position + offsetFromParent;
        
    }
    
    private void Update()
    {
        // Rotate to look at the target and apply rotation offset.
        transform.LookAt(worldPosition: FlatTargetPosition, worldUp: Vector3.up);
        transform.Rotate(eulers: offsetRotation);
        

    }
    
    /*private void OnDrawGizmosSelected()
    {
        //Draw a wire disc at the location and the rotation this object will be at in runtime.
        UnityEditor.Handles.color = Color.red;

        //Use matrices to rotate the disc to the rotation of the object.

        //Save the current matrix
        Matrix4x4 matrix = UnityEditor.Handles.matrix;

        //Set the position of the matrix to the position of the object
        Vector3 selfPosition = parent.TransformPoint(offsetFromParent);

        //Create a lookat matrix
        Matrix4x4 lookAtMatrix = Matrix4x4.LookAt(from: selfPosition, to: FlatTargetPosition, up: Vector3.up);

        //Rotate the matrix by the rotation offset
        lookAtMatrix *= Matrix4x4.Rotate(q: Quaternion.Euler(euler: offsetRotation));

        //Set the matrix to the lookat matrix
        UnityEditor.Handles.matrix = lookAtMatrix;

        //Draw the wire disc
        UnityEditor.Handles.DrawWireDisc(center: Vector3.zero, normal: Vector3.up, radius: 0.5f);

        //Restore the matrix
        UnityEditor.Handles.matrix = matrix;

        //Draw a line from the center of the disc to the target
        UnityEditor.Handles.DrawLine(p1: selfPosition, p2: target.position);
    }*/

}
