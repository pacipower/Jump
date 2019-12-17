using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{
    public static TMP_Text ScoreBoard;
    public static int score;
    public static int highScore;
    public static int highscoreBottom;
    public static bool addScore;
    string playerName;
    string highscoreString;

    public struct Highscores
    {
        public string name;
        public int score;
    }
    public static List<Highscores> highscoreList = new List<Highscores>();

    // Start is called before the first frame update
    void Start()
    {
        addScore = false;
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("playerName", playerName)))
        {
            playerName = "Anonymus";
        }
        else playerName = PlayerPrefs.GetString("playerName", playerName);
        ScoreBoard = GetComponent<TMP_Text>();
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore",highScore);
        highscoreBottom = PlayerPrefs.GetInt("highscoreBottom", highscoreBottom);
        ScoreBoard.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale==0)
        {
            ScoreBoard.enabled = false;
        }
        else ScoreBoard.enabled = true;

        if (addScore)
        {
            AddHighscoreEntry(playerName, score);
            addScore = false;
        }
    }



    public static void UpdateScore()
    {
        ScoreBoard.text = score.ToString();
    }




    private void AddHighscoreEntry(string name, int score)
    {
        highscoreList.Clear();
        Highscores newHighscore = new Highscores { name = name, score = score };
        Debug.Log(newHighscore.name+ newHighscore.score);
        if (PlayerPrefs.HasKey("highscoreTable"))
        {


            highscoreString = PlayerPrefs.GetString("highscoreTable");
            Debug.Log(highscoreString);
            if (!string.IsNullOrEmpty(highscoreString))
            {
                string[] highscores = highscoreString.Split(';');

                foreach (var item in highscores)
                {
                    Highscores h;
                    string[] highscores2 = item.Split(' ');
                    h.name = highscores2[0];
                    h.score = int.Parse(highscores2[1]);
                    highscoreList.Add(h);
                }
            }
        }
        highscoreList.Add(newHighscore);
        Debug.Log($"{highscoreList[0].name} {highscoreList[0].score}");
        Debug.Log(highscoreList.Count);
        if (highscoreList.Count > 1)
        {
            for (int i = 0; i < highscoreList.Count; i++)
            {
                for (int j = i + 1; j < highscoreList.Count; j++)
                {
                    if (highscoreList[j].score > highscoreList[i].score)
                    {
                        Highscores tmp = highscoreList[i];
                        highscoreList[i] = highscoreList[j];
                        highscoreList[j] = tmp;
                    }
                }
            }
        }

        if (highscoreList.Count>10)
        {
            highscoreList.RemoveAt(10);
        }

        if (highscoreList.Count==10)
        {
            highscoreBottom = highscoreList[9].score;
        }

        string[] highscoreArray = new string[highscoreList.Count];

        for (int i = 0; i < highscoreList.Count; i++)
        {
            highscoreArray[i] = $"{highscoreList[i].name} {highscoreList[i].score}";
        }
        Debug.Log(highscoreArray[0]);

        highscoreString = string.Join(";", highscoreArray);
        Debug.Log(highscoreString);
        PlayerPrefs.SetString("highscoreTable", highscoreString);
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        PlayerPrefs.SetInt("highscoreBottom", highscoreBottom);
        PlayerPrefs.Save();



    }




}
