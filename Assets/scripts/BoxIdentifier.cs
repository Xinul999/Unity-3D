using System;
using UnityEngine;

public class BoxIdentifier : MonoBehaviour
{
    public int boxID; //ce sera 1 2 ou 3, on va voir ça dans
    [SerializeField] private Rigidbody boxRigid;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) {
            Debug.Log("BoxIdentifier " + boxID + " détectée par " + player.name);  
            Vector3 direction = player.transform.position - transform.position;
            boxRigid.AddForce(direction.normalized * 10f, ForceMode.Impulse);
        }
      
    }
}