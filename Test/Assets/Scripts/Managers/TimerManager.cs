using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    GameManager gameManager;
    
    public static TimerManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        gameManager = GameManager.instance;
    }

    [SerializeField] float defaultGameTimeM = 5f;
    public float gameTime { get; private set; } = 0f;
    private bool gameIsOn { get; set; } = false;

    private void Update()
    {
        if (gameIsOn) {
            UpdateGameTimer();
            if (gameTime <= 0)
                EndGame();
        }
    }


    public void PauseGame()
    {

        gameIsOn = false;
        Time.timeScale = 0;

    }

    public void ContinueGame()
    {
        gameIsOn = true;
        Time.timeScale = 1;
    }


    public void NewGameStart()
    {
        gameTime = defaultGameTimeM * 60f;
        gameIsOn = true;
        Time.timeScale = 1;

    }

    public void EndGame()
    {
        gameIsOn = false;
        gameManager.OnGameEnd();
        Time.timeScale = 0;
    }

    public void UpdateGameTimer()
    {
        gameTime -= Time.deltaTime;

    }
}
