using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSM : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(GoToStart());
    }

    IEnumerator GoToStart()
    {
        yield return new WaitForSeconds(2);
        gm.ToStart();
    }
}
