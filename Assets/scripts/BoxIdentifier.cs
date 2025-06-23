using System;
using UnityEngine;

public class BoxIdentifier : MonoBehaviour
{
    public int boxID; //ce sera 1 2 ou 3, on va voir ça dans
    [SerializeField] private Rigidbody boxRigid;
    
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter avec " + other.gameObject.name);
        
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) {
            Debug.Log("BoxIdentifier " + boxID + " (trigger) détectée par " + player.name);  
            Vector3 direction = transform.position - player.transform.position;
            boxRigid.AddForce(direction.normalized * 15f, ForceMode.Impulse);
        }
    }
}
