using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    Vector3 position;
    Text playerText;
    GameManager gm;

    private void Start()
    {
        playerText = this.GetComponent<Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.StartText();
    }
    private void Update()
    {
        position = target.position;
        position.z = -2;
        position.x -= 0.6f;
        position.y += 0.65f;
        transform.position = position;
    }


    public IEnumerator TextON(string playerText)
    {
        this.playerText.text = playerText;
        yield return new WaitForSeconds(2);
        this.playerText.text = "";
    }

}
