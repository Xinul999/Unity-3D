using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //Au clic du bouton pour entrer dans la 1ere scene
    public void StartGame()
    {
        SceneManager.LoadScene("room1"); 
    }
}
