using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Timer timerGlobaleGame;
    private bool isGameOver;

    private void Start() {
        timerGlobaleGame.StartTimer();
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            isGameOver = false;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public bool GetGameOver() {
        return isGameOver;
    }

    public void SetGameOver(bool gameOver) {
        this.isGameOver = gameOver;
    }

    public void DebugLog() {
        Debug.Log("Game Over: " + isGameOver);
    }
    
    
}
