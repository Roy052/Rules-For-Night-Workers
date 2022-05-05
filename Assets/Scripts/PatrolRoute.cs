using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    GameManager gm;
    int num;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        num = this.name[5] - '0';
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Security")
        {
            gm.patrol[num] = true;
        }
    }
}
