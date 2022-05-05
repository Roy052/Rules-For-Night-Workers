using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    GameManager gm;
    AudioSource audioSource;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if(this.name == "Start")
        {
            StartCoroutine(WaitForStart());
        }
        else if(this.name == "Exit")
        {
            gm.ExitGame();
        }
    }

    IEnumerator WaitForStart()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        gm.StartGame();
    }
}
