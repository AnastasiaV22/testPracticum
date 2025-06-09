using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class MusicManager : MonoBehaviour
{
    GameManager gameManager;

    public static MusicManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameManager = GameManager.instance;
        }
    }
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip backgroundMusic;

    public void PlayButtonClickSound ()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
