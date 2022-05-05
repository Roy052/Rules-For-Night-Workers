using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTable : MonoBehaviour
{
    GameManager gm;
    Interactive interactive;
    public bool anomaly = false;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;


    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        interactive = this.GetComponent<Interactive>();
        interactive.interactable = false;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (anomaly == true && gm.grabBook == true && interactive.inInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (interactive.isChanged == false)
            {
                gm.SendText("Hand over the book");
                interactive.isChanged = true;
                AnomalyOFF();
            }
        }
    }

    public void AnomalyON()
    {
        spriteRenderer.sprite = interactive.change_Image;
        BookShelf[] bookShelves = GameObject.FindObjectsOfType<BookShelf>();
        for (int i = 0; i < bookShelves.Length; i++)
            bookShelves[i].ToInteractable();
        interactive.interactable = true;
        anomaly = true;
        audioSource.Play();
    }

    public void AnomalyOFF()
    {
        spriteRenderer.sprite = interactive.original_image;
        gm.anomalyExist = false;
        anomaly = false;
        audioSource.Stop();
    }
}
