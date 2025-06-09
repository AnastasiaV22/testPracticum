using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointerDoorController : MonoBehaviour
{
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        rend.material.color = Color.grey;
        MusicManager.instance.PlayButtonClickSound();
        InteractableItemsCollection.instance.SetItemUsed(gameObject);
    }


}
