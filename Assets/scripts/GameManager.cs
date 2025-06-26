using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    [SerializeField] private Timer timerGlobaleGame;

    private bool isGameOver;

    private void Start()
    {
        timerGlobaleGame.StartTimer();
    }

    void Awake()
    {
        isGameOver = false;
        if (GameObject.FindGameObjectsWithTag("GameManager").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public bool GetGameOver()
    {
        return isGameOver;
    }

    public void SetGameOver(bool gameOver)
    {
        this.isGameOver = gameOver;
    }

    public void DebugLog()
    {
        Debug.Log("Game Over: " + isGameOver);
    }
    public void ReloadScene()
    {
        Debug.Log("Reloading Scene");
        isGameOver = false;
        timerGlobaleGame.StartTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DebugTest()
    {
        Debug.Log("je suis le debug weeeeeeeeeeeeeeeeeee");
    }

    
}