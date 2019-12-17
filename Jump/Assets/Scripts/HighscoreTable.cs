using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    float templateHeight;
    

    private void Awake()
    {
        
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        Score.highscoreList.Clear();

        string highscoreString = PlayerPrefs.GetString("highscoreTable");

        Debug.Log(highscoreString);

        if (!string.IsNullOrEmpty(highscoreString))
        {



            string[] highscores = highscoreString.Split(';');

            foreach (var item in highscores)
            {
                Score.Highscores h;
                string[] highscores2 = item.Split(' ');
                h.name = highscores2[0];
                h.score = int.Parse(highscores2[1]);
                Score.highscoreList.Add(h);
            }


            for (int i = 0; i < Score.highscoreList.Count; i++)
            {
                for (int j = i + 1; j < Score.highscoreList.Count; j++)
                {
                    if (Score.highscoreList[j].score > Score.highscoreList[i].score)
                    {
                        Score.Highscores tmp = Score.highscoreList[i];
                        Score.highscoreList[i] = Score.highscoreList[j];
                        Score.highscoreList[j] = tmp;
                    }
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (Score.Highscores highscoreEntry in Score.highscoreList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        

    }

    private void CreateHighScoreEntryTransform(Score.Highscores highscoreEntry, Transform container, List<Transform> transformlist)
    {
        //if (Level.landscape)
        //{
            templateHeight = 25f;
        //}
        //else templateHeight = 50f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformlist.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformlist.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        transformlist.Add(entryTransform);
    }

    

    
    







}
