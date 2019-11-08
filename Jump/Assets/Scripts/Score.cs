using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public static TMP_Text ScoreBoard;
    public static int score;
    public static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        ScoreBoard = GetComponent<TMP_Text>();
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore",highScore);
        //ScoreBoard.text = $"Highscore:\n{highScore}\nScore:\n{score}";
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
    }



    public static void UpdateScore()
    {
        //ScoreBoard.text = $"Highscore:\n{highScore}\nScore:\n{score}";
        ScoreBoard.text = score.ToString();
    }

    
}
