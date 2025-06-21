using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;

    // Décalage en position par rapport à la cible + lissage pour mouvement fluide
    public Vector3 offset = new Vector3(0, 5, -10);
   
    public float smoothSpeed = 0.125f;

    // Field of View (60 est une valeur classique).
    public float fixedFOV = 60f;

   
    void LateUpdate()
    {
        // Position souhaitée = position du joueur + décalage
        Vector3 desiredPosition = target.position + offset;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Mise à jour position de la caméra
        transform.position = smoothedPosition;

        // Orientation caméra pour regarder la cible
        transform.LookAt(target);

        // Forcer le Field of View pour éviter un zoom inattendu
        Camera cam = GetComponent<Camera>();
        if(cam != null)
        {
            cam.fieldOfView = fixedFOV;
        }
    }
}

