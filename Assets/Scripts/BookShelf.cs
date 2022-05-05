using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    GameManager gm;
    Interactive interactive;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        interactive = this.GetComponent<Interactive>();
        interactive.interactable = false;
    }

    private void Update()
    {
        if (interactive.inInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (interactive.isChanged == false)
            {
                gm.SendText("Grab a book from " + this.name);
                interactive.isChanged = true;
                gm.grabBook = true;
            }
        }
    }

    public void ToInteractable()
    {
        interactive.interactable = true;
    }
}
