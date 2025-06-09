using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;

    public static UIManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameManager = GameManager.instance;
        }
    }

    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject inGameUIPanel;

    [SerializeField] GameObject homeUIPanel;
    [SerializeField] GameObject notesViewPanel;

    [SerializeField] Text min;
    [SerializeField] Text sec;

    [SerializeField] Text messageText;

    private void FixedUpdate()
    {
        if (messageText.color.a > 0)
        {
            messageText.material.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, messageText.color.a /2);
            Debug.Log($"{messageText.color.a}");

        }
    }

    public void MainMenuOpen()
    {
        mainMenuPanel.SetActive(true);
        inGameUIPanel.SetActive(false);
    }

    public void GameUIOpen()
    {
        mainMenuPanel.SetActive(false);
        inGameUIPanel.SetActive(true);
    }

    public void OpenHomeUIPanel()
    {
        homeUIPanel.SetActive(true);
        notesViewPanel.SetActive(false);
    }

    public void OpenNotesViewUIPanel()
    {
        homeUIPanel.SetActive(false);
        notesViewPanel.SetActive(true);
    }


    public void ChangeToDefaultActivePanels() {
        mainMenuPanel.SetActive(true);
        inGameUIPanel.SetActive(false);
        homeUIPanel.SetActive(true);
        notesViewPanel.SetActive(false);
    
    }   

    public void OnStartButtonClick() 
    {
        GameUIOpen();
        gameManager.OnGameStart();
    }

    public void OnExitButtonClick()
    {
        ChangeToDefaultActivePanels();
    }

    public void OnGameBackButtonClick() {
        OpenHomeUIPanel();
        gameManager.OnContinueGame();
    }


    public void ShowCurrentTime(string _min, string _sec)
    {
        min.text = _min;
        sec.text = _sec;
    }

    internal void DisplayMessage(string message)
    {
        messageText.text = message;

        Color newColor = new Color(190, 238, 227, 255);
        messageText.color = newColor;
    }

}
