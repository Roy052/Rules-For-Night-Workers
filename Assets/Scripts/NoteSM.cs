using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSM : MonoBehaviour
{
    public Text headline;
    public Text[] texts;
    public Sprite arrowLeftNormal, arrowRightNormal, arrowLeftHover, arrowRightHover;
    public bool[] textCondition;
    public int pageNum = 0, maxPage = 2;
    public bool check = false;
    public GameObject arrowLeft, arrowRight;
    public Font normal, handwrite;
    public GameObject map;
    public string[,] sentences = {
        {
            "1. Follow the dress code",
            "2. Do not leave the workplace",
            "3. Patrol every 2 hours",
            "4. Close the window",
            "5. If anyone breaks in, subdue them and report them to the police",
            "Please follow the rules. \nViolation of the rules can result in disadvantages such as salary reduction, suspension, and dismissal."
        },
        {
            "Patrol Route",
            "",
            "",
            "",
            "",
            ""
        },
        {
            "If you read this page, you're damned.\nIf you keep the rules, you can survive.\nThese rules are come from experience",
            "If you heard a \'BEEP\'sounds, get a book from bookshelves and go to returns and hand over it.",
            "If a tree bleeds, ... I don't know",
            "If you heard the sound of the wind, check windows in the north.\n" +
                "If all windows are closed, ignore it and end the patrol.",
            "",
            ""
        }
    };

    private void Start()
    {
        pageNum = 0;
        arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowLeftNormal;
        arrowRight.GetComponent<SpriteRenderer>().sprite = arrowRightHover;
        texts[0].text = sentences[pageNum, 0];
        texts[1].text = sentences[pageNum, 1];
        texts[2].text = sentences[pageNum, 2];
        texts[3].text = sentences[pageNum, 3];
        texts[4].text = sentences[pageNum, 4];
        texts[5].text = sentences[pageNum, 5];
        map.SetActive(false);
    }
    public void BeforePage()
    {
        pageNum--;
        arrowRight.GetComponent<SpriteRenderer>().sprite = arrowRightHover;
        if(pageNum == 0)
        {
            arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowLeftNormal;
        }
        if (pageNum == 0 || pageNum == 1)
        {
            
            texts[0].font = normal;
            texts[1].font = normal;
            texts[2].font = normal;
            texts[3].font = normal;
            texts[4].font = normal;
            texts[5].font = normal;
        }
        if (pageNum == 1)
            map.SetActive(true);
        else
            map.SetActive(false);

        texts[0].text = sentences[pageNum, 0];
        texts[1].text = sentences[pageNum, 1];
        texts[2].text = sentences[pageNum, 2];
        texts[3].text = sentences[pageNum, 3];
        texts[4].text = sentences[pageNum, 4];
        texts[5].text = sentences[pageNum, 5];
    }
    public void NextPage()
    {
        pageNum++;
        arrowLeft.GetComponent<SpriteRenderer>().sprite = arrowLeftHover;
        if (pageNum == maxPage)
        {
            arrowRight.GetComponent<SpriteRenderer>().sprite = arrowRightNormal;

            texts[0].font = handwrite;
            texts[1].font = handwrite;
            texts[2].font = handwrite;
            texts[3].font = handwrite;
            texts[4].font = handwrite;
            texts[5].font = handwrite;
        }

        if (pageNum == 1)
            map.SetActive(true);
        else
            map.SetActive(false);

        texts[0].text = sentences[pageNum, 0];
        texts[1].text = sentences[pageNum, 1];
        texts[2].text = sentences[pageNum, 2];
        texts[3].text = sentences[pageNum, 3];
        texts[4].text = sentences[pageNum, 4];
        texts[5].text = sentences[pageNum, 5];
    }
}
