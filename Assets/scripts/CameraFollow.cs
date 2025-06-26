using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;


    public float distance = 10.0f;
    public float height = 5.0f;
    

    public float rotationSpeed = 100.0f;
    

    public float mouseSensitivity = 4.0f;
    

    private float currentRotation = 0.0f;
    

    public float smoothSpeed = 0.125f;

 
    public float fixedFOV = 60f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        currentRotation += mouseX * rotationSpeed * Time.deltaTime;
        
        Vector3 desiredPosition = target.position;
        desiredPosition.y += height; 
        
        desiredPosition.x += Mathf.Sin(currentRotation * Mathf.Deg2Rad) * distance;
        desiredPosition.z += Mathf.Cos(currentRotation * Mathf.Deg2Rad) * distance;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
        
        transform.LookAt(target);
        
        Camera cam = GetComponent<Camera>();
        if(cam != null)
        {
            cam.fieldOfView = fixedFOV;
        }
    }
}