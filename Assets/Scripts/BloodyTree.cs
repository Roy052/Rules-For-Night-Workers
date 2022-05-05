using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyTree : MonoBehaviour
{
    GameManager gm;
    Interactive interactive;
    public bool anomaly = false;
    SpriteRenderer spriteRenderer;
    bool mouseON = false, deathTimerON = false;
    float deathTimer = 0,timer = 0;
    AudioSource audioSource;

    public Sprite attackingTree;
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
        if (timer >= 5)
        {
            if (interactive.isChanged == false)
            {
                gm.SendText("Is it over?");
                interactive.isChanged = true;
                AnomalyOFF();
            }
        }

        if(deathTimer >= 15)
        {
            gm.GameOver();
        }
        
    }

    private void FixedUpdate()
    {
        if (mouseON)
            timer += Time.deltaTime;
        if(deathTimerON == true)
        {
            deathTimer += Time.deltaTime;
        }
    }

    public void AnomalyON()
    {
        spriteRenderer.sprite = interactive.change_Image;
        interactive.interactable = true;
        anomaly = true;
    }

    public void AnomalyOFF()
    {
        spriteRenderer.sprite = interactive.original_image;
        gm.anomalyExist = false;
        anomaly = false;
        deathTimerON = false;
    }

    private void OnMouseEnter()
    {
        if(anomaly == true)
        {
            mouseON = true;
            spriteRenderer.sprite = attackingTree;
            audioSource.Play();
            deathTimerON = true;

        }
        
    }

    private void OnMouseExit()
    {
        if(anomaly == true)
        {
            mouseON = false;
            spriteRenderer.sprite = interactive.change_Image;
        }
    }
}
