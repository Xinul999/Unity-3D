using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerGameOver = 120f;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject finalGameOverPanel;
    private bool isTimerRunning = false;
    void Start() {
      finalGameOverPanel.gameObject.SetActive(false);
     
    }

    private void Awake() {
        gameObject.SetActive(false);
    }

    void Update() {
       if (!isTimerRunning) return;
       UpdateTimerVisualisation();
       if (!GameManager.Instance.GetGameOver()) {
           timerGameOver -= Time.deltaTime;
       }
          
       if (timerGameOver <= 0) {
           timerText.gameObject.SetActive(false);
           timerText.canvasRenderer.SetAlpha(0); 
           GameOver();
       }
     
    }
    private void UpdateTimerVisualisation() {
        TimeSpan timeStamp = TimeSpan.FromSeconds(timerGameOver);
        timerText.text = timeStamp.ToString("mm' : 'ss' : 'ff");

      
    }
    private void GameOver() {
        finalGameOverPanel.gameObject.SetActive(true);
        GameManager.Instance.SetGameOver(true);
    }

    public void StartTimer() {
        isTimerRunning = true;
        gameObject.SetActive(true);
    }
}
