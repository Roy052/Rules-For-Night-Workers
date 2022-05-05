using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    GameObject alertWhite;
    public Sprite original_image;
    public Sprite change_Image;
    public bool isChanged;
    public bool inInteract;
    public bool interactable = true;

    private void Start()
    {
        alertWhite = GameObject.FindGameObjectWithTag("Alert");
        inInteract = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(interactable == true && collision.gameObject.name == "Security")
        {
            alertWhite.GetComponent<AlertMark>().AlertON();
            inInteract = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (interactable == true && collision.gameObject.name == "Security")
        {
            alertWhite.GetComponent<AlertMark>().AlertOFF();
            inInteract = false;
        }
    }

}
