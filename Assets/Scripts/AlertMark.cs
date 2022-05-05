using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertMark : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    Vector3 position;
    GameManager gm;
    bool onetime = false, onetime1 = false;
    private void Update()
    {
        position = target.position;
        position.z = -2;
        position.x += 0.25f;
        position.y += 0.65f;
        transform.position = position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void LateUpdate()
    {
        if (!onetime)
        {
            this.AlertOFF();
            onetime = true;
        }
    }

    public void AlertON()
    {
        this.gameObject.SetActive(true);
        if (gm.clock == 1 && !onetime1)
        {
            gm.SendText("Press E to interact");
            onetime1 = true;
        }
    }

    public void AlertOFF()
    {
        this.gameObject.SetActive(false);
    }
}
