using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionController : MonoBehaviour
{
    GameManager gameManager;
    public Renderer rend;
    void Start()
    {
        gameManager = GameManager.instance;
        rend = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {

        Debug.Log("Тыкаем");
        rend.material.color = Color.blue;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        Debug.Log("дотыкали");

        rend.material.color = Color.grey;
        MusicManager.instance.PlayButtonClickSound();
        gameManager.OnPauseGame();
    }



}
