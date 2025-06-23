using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float orignalTimer;
    private GameManager gameManager;
    private float timer = 120f;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject finalGameOverPanel;
    private bool isTimerRunning = false;
    void Start() { 
        timer = orignalTimer; 
        finalGameOverPanel.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*private void Awake() {
        gameObject.SetActive(false);
    }*/

    void Update() {
       if (!isTimerRunning) return;
       UpdateTimerVisualisation();
       if (!gameManager.GetGameOver()) {
           timer -= Time.deltaTime;
           if (timer <= 0) {
               //Debug.Log("Timer finis " + name);
               PanelInvisible();
               GameOver();
           }
       }
       
    }
    private void UpdateTimerVisualisation() {
        TimeSpan timeStamp = TimeSpan.FromSeconds(timer);
        timerText.text = timeStamp.ToString("mm' : 'ss' : 'ff");

      
    }
    private void GameOver() {
        Debug.Log("Game Over!");
        finalGameOverPanel.gameObject.SetActive(true);
        gameManager.SetGameOver(true);
    }

    public void StartTimer() {
        this.timer = orignalTimer;
        isTimerRunning = true;
        PanelVisible();
        finalGameOverPanel.gameObject.SetActive(false);
    }

    public void PanelVisible() {
        //Debug.Log("Text visible");
        timerText.gameObject.SetActive(true);
    }

    public void PanelInvisible() {
        //Debug.Log("Text invisible");
        timerText.gameObject.SetActive(false);
    }
    
    public void SetTimer(bool etatTimer) {
        isTimerRunning = etatTimer;
    }
    public void ReInitializeTimer() {
        timer = orignalTimer;
    }
}
