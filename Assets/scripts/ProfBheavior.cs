using System;
using UnityEngine;

public class ProfBheavior : MonoBehaviour
{
    [SerializeField] private Timer timerQuizz;
    void Start() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<PlayerController>(out PlayerController player)) {
            timerQuizz.StartTimer();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
