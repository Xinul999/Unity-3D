using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour
{
    public string correctAnswerTag = "Cube"; // Vérifie que c'est le bon cube réponse
    public string nextSceneName = "room2"; // Nom de la scène suivante

    // Option "Is Trigger" cochée dans le collider de l'objet.
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(correctAnswerTag))  {
           
            Debug.Log("Bonne réponse !");
            // Charge scène suivante
            SceneManager.LoadScene(nextSceneName);
        }
    }

 
}
