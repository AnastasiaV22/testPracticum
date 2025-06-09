
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerController : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameObject connectedThing;

    public Renderer rend;
    void Start()
    {
       // gameManager = GameManager.instance;
        rend = GetComponent<Renderer>();
        gameManager = GameManager.instance;
    }

    private void OnMouseEnter()
    {
        rend.material.color = Color.green;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        MusicManager.instance.PlayButtonClickSound();
        rend.material.color = Color.white;

        connectedThing.SetActive(true);

        gameManager.DisplayMessage("ой ей ");
        Component component = gameObject.GetComponent<TriggerController>();
        Destroy(component);
    }


}
