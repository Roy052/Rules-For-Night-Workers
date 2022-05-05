using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneSM : MonoBehaviour
{
    GameManager gm;
    public Text[] Time;
    public GameObject[] messageBox;
    public Text[] message;
    AudioSource audioSource;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        switch (gm.gameState)
        {
            case 1:
                Time[0].text = "24:00";
                Time[1].text = "24:00";
                StartCoroutine(MessageSend());
                break;
            case 2:
                Time[0].text = "02:00";
                Time[1].text = "02:00";
                StartCoroutine(MessageSend());
                break;
            case 3:
                Time[0].text = "04:00";
                Time[1].text = "04:00";
                StartCoroutine(MessageSend());
                break;
            case 4:
                Time[0].text = "06:00";
                Time[1].text = "06:00";
                StartCoroutine(MessageSend());
                break;
        }
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    IEnumerator MessageSend()
    {
        Debug.Log(gm.day + "days");
        if(gm.day == 0 && gm.gameState == 1)
        {
            message[0].text = "I'm sorry, Dave. \nOur library night guard has disappeared. \nPlease work for a few days.";
            messageBox[1].SetActive(false);
            yield return new WaitForSeconds(4f);
            audioSource.Play();
            messageBox[1].SetActive(true);
            message[1].text = "There will be rules for night workers in the drawer.\nYou just have to keep it.";
            yield return new WaitForSeconds(4f);
        }
        else if(gm.day == 1)
        {
            messageBox[0].SetActive(true);
            message[0].text = "Did you see the last page of notes? \nIt's just kidding. \nDon't worry.";
            messageBox[1].SetActive(false);
            yield return new WaitForSeconds(4.5f);
        }
        else
        {
            messageBox[0].SetActive(false);
            messageBox[1].SetActive(false);
            yield return new WaitForSeconds(1.5f);
        }
        
        gm.StartWork();
    }
}
