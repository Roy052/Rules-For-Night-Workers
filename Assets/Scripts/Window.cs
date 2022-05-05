using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    GameManager gm;
    Interactive interactive;
    public bool anomaly = false;
    SpriteRenderer spriteRenderer;
    Vector3 position;
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
        if(anomaly == true)
        {
            gm.anomalyExist = false;
        }
            
        if (anomaly == true && interactive.inInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (interactive.isChanged == false)
            {
                gm.SendText("Uh?");
                interactive.isChanged = true;
                AnomalyOFF();
            }
        }
    }

    public void AnomalyON()
    {
        spriteRenderer.sprite = interactive.change_Image;
        interactive.interactable = true;
        anomaly = true;
        audioSource.Play();
        gm.anomalyExist = false;
        gm.patrol[0] = true;
        for (int i = 3; i < 5; i++) gm.patrol[i] = true;
    }

    public void AnomalyOFF()
    {
        
        position = transform.position;
        position.y -= 0.65f;
        transform.position = position;
        spriteRenderer.sprite = interactive.original_image;
        anomaly = false;
        StartCoroutine(WaitToDeath());
        
    }

    IEnumerator WaitToDeath()
    {
        yield return new WaitForSeconds(0.5f);
        gm.GameOver();
    }

    
}
