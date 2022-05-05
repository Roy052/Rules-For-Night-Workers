using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Interactive interactive;
    SpriteRenderer spriteRenderer;
    GameManager gm;
    AudioSource audioSource;

    private void Start()
    {
        interactive = this.gameObject.GetComponent<Interactive>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (interactive.inInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (interactive.isChanged == false)
            {
                spriteRenderer.sprite = interactive.change_Image;
                interactive.isChanged = true;
                gm.NoteGained();
                audioSource.Play();
            }
        }
    }
}
