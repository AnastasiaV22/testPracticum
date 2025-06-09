using System;
using System.Collections;
using System.Collections.Generic;
using Test.Inputs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] GameObject gameControllers;
    UIManager uiManager;
    MusicManager musicManager;
    TimerManager timerManager;
    
    Settings settings;
    InteractableItemsCollection itemsCollection;

    PrefabsList prefabsList;
    ItemPlacesList itemPlacesList;
    OpenNotesCollection openNotesCollection;


    void Start()
    {
        // Managers
        uiManager = UIManager.instance;
        musicManager = MusicManager.instance;
        timerManager = TimerManager.instance;
        //Storage
        itemsCollection = InteractableItemsCollection.instance;
        openNotesCollection = OpenNotesCollection.instance;

        // Settings and Date
        settings = Settings.GetInstance();
        prefabsList = PrefabsList.instance;
        itemPlacesList = ItemPlacesList.instance;

        uiManager.ChangeToDefaultActivePanels();

    }

    private void FixedUpdate()
    {

        float time = timerManager.gameTime;
        uiManager.ShowCurrentTime(Convert.ToString((int)(time / 60)), Convert.ToString((int)(time % 60)));
    }

    public void OnGameStart()
    {
        timerManager.NewGameStart();
        itemsCollection.GenerateItems();


        gameControllers.GetComponent<InputController>().enabled = true;

    }

    public void OnGameEnd()
    {
        gameControllers.GetComponent<InputController>().enabled = false;
        uiManager.OpenNotesViewUIPanel();



    }

    public void OnPauseGame()
    {
        gameControllers.GetComponent<InputController>().enabled = false;
        uiManager.OpenNotesViewUIPanel();
        timerManager.PauseGame();

    }

    public void OnContinueGame()
    {
        gameControllers.GetComponent<InputController>().enabled = true;
        timerManager.ContinueGame();

    }

/*
    //save to note
    public void AddNote(string type, string note)
    {
        openNotesCollection.AddNewNote(type, note);
    }
 */

    public void DisplayMessage(string message)
    {
        uiManager.DisplayMessage(message);
    }



}
