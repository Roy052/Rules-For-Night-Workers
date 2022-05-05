using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public int eventNum;
    public bool selected;
    public string happen, handle;

    private void Start()
    {
        if (eventNum == 0)
        {
            happen = "If heard a \'BEEP\'sounds from returns";
            handle = "get a book from bookshelves and hand over the book";
        }
        
        else if (eventNum == 1)
        {
            happen = "If tree is bleeding";
            handle = "light the tree for 10 seconds";
        }
        else if (eventNum == 2)
        {
            happen = "If you can hear the sound of the wind even after closing the window";
            handle = "ignore it and end the patrol";
        }
        else if (eventNum == 3)
        {
            happen = "If someone is standing in front of the security office door";
            handle = "don't move and wait until it disappears.";
        }
        else if  (eventNum == 4)
        {
            happen = "If the bookshelf is fallen down";
            handle = "end the patrol immediately";
        }
    }

    public void EventSelected()
    {
        if(eventNum == 0)
        {
            this.gameObject.GetComponent<ReturnTable>().AnomalyON();
        }
        else if (eventNum == 1)
        {
            this.gameObject.GetComponent<BloodyTree>().AnomalyON();
        }
        else if (eventNum == 2)
        {
            this.gameObject.GetComponent<Window>().AnomalyON();
        }
        else if(eventNum == 3)
        {

        }
    }
}
