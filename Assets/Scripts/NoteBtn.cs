using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBtn : MonoBehaviour
{
    GameManager gm;
    NoteSM nsm;
    AudioSource audioSource;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        nsm = GameObject.Find("NoteSM").GetComponent<NoteSM>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed");
        Debug.Log(nsm.maxPage + "," + nsm.pageNum);
        if (this.name == "Exit") gm.NoteOFF();
        else if (this.name == "Next" && nsm.pageNum != nsm.maxPage)
        {
            nsm.NextPage();
            audioSource.Play();
        }
        else if (this.name == "Before" && nsm.pageNum != 0)
        {
            nsm.BeforePage();
            audioSource.Play();
        }
    }
}
