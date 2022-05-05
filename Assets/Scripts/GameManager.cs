using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int gameState; // 0 : Start, 1 : Phone 24:00, 2 : Phone 02:00, 3 : Phone 04:00, 4 : Phone 06:00
    // 5 : Security before patrol, 6 : Security after patrol, 7 : Main Hall, 8 : GameOver, 9 : GameEnd
    public bool noteON = false;
    public int clock = 1;
    public int day = 0;
    bool noteGain = false;
    PlayerText playerText;
    Events[] events;
    bool onetime = false;
    int beforeRandnum, randnum;
    public bool[] patrol;

    public bool anomalyExist = false;

    public bool grabBook = false;

    GameObject window;

    private void Start()
    {
        DontDestroyOnLoad(this);
        patrol = new bool[6];
    }
    private void Update()
    {
        if (noteGain == true && (gameState == 7 || gameState == 5) && Input.GetKeyDown(KeyCode.Tab))
        {
            if (noteON == false)
            {
                SceneManager.LoadScene("Note", LoadSceneMode.Additive);
                noteON = true;
            }
            else
            {
                SceneManager.UnloadSceneAsync("Note");
                noteON = false;
            }   
        }
        if (!onetime && clock == 1 && gameState == 7)
        {
            events = GameObject.FindObjectsOfType<Events>();
            for (int i = 0; i < events.Length; i++)
                Debug.Log(events[i].name);
            onetime = true;
        }

        if (!onetime && clock == 3 && gameState == 7)
        {
            events = GameObject.FindObjectsOfType<Events>();
            beforeRandnum = Random.Range(0, events.Length);
            events[beforeRandnum].EventSelected();
            onetime = true;
            anomalyExist = true;
        }

        if(!onetime && clock == 4 && gameState == 7)
        {
            events = GameObject.FindObjectsOfType<Events>();
            if (events[beforeRandnum].name == "Window5")
                events[beforeRandnum].GetComponent<Window>().anomaly = false;
            randnum = Random.Range(0, events.Length - 1);
            if (randnum >= beforeRandnum) randnum += 1;
            events[randnum].EventSelected();
            onetime = true;
            anomalyExist = true;
        }

        if(gameState == 7 && patrol[5] == true)
        {
            int i;
            for (i = 0; i < 5; i++)
                if (patrol[i] == false) break;
            if(i == 5)
            {
                if (anomalyExist == false)
                    PatrolEnd();
                if (anomalyExist == true)
                    GameOver();
            }
        }

    }
    public void StartText()
    {
        playerText = GameObject.Find("PlayerText").GetComponent<PlayerText>();
        if (clock == 1 && gameState == 5) StartCoroutine(playerText.TextON("Press WASD to Move"));
        if(clock == 1 && gameState == 7) StartCoroutine(playerText.TextON("Move Mouse to Light"));
    }

    public void SendText(string sendText)
    {
        StartCoroutine(playerText.TextON(sendText));
    }

    public void NoteGained()
    {
        noteGain = true;
        StartCoroutine(playerText.TextON("Press TAB to see note"));
    }
    public void NoteOFF()
    {
        SceneManager.UnloadSceneAsync("Note");
        noteON = false;
        if (clock == 1 && gameState == 5) StartCoroutine(playerText.TextON("It's time to patrol"));
    }
    public void StartGame()
    {
        gameState = 1;
        SceneManager.LoadScene("Phone");
    }

    public void StartWork()
    {
        gameState = 5;
        SceneManager.LoadScene("Security_Room");
    }

    public void PatrolStart()
    {
        gameState = 7;
        SceneManager.LoadScene("MainHall");
        onetime = false;
        for (int i = 0; i < 6; i++)
            patrol[i] = false;
    }

    public void PatrolEnd()
    {
        Debug.Log("Time is " + clock);
        if (clock == 4)
        {
            gameState = 9;
            GameEnd();
        }
        else
        {
            clock++;
            for (int i = 0; i < 6; i++)
                patrol[i] = false;
            gameState = clock;
            SceneManager.LoadScene("Phone");
        }    
    }

    public void OpenWindow()
    {
        window = GameObject.Find("Window5");
        window.GetComponent<Window>();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GameEnd()
    {
        SceneManager.LoadScene("End");
    }

    public void GameOver()
    {
        gameState = 8;
        Debug.Log("GameOver");
        SceneManager.LoadScene("GameOver");
    }

    public void ToStart()
    {
        SceneManager.LoadScene("Start");
    }

}
