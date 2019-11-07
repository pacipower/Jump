using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static TMP_Text ScoreBoard;
    //public static Text gameOverText;
    public static int score;
    public static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        ScoreBoard = GetComponent<TMP_Text>();
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore",highScore);
        ScoreBoard.text = $"Highscore:\n{highScore}\nScore:\n{score}";
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public static void UpdateScore()
    {
        ScoreBoard.text = $"Highscore:\n{highScore}\nScore:\n{score}";
    }

    //public static void UpdateGameOverText()
    //{
    //    //Text gameOverText = gameoverUI.GetComponent<Text>();

    //    gameOverText.text = $"Game Over\nYour Score:\n{score}";
    //    if (score > highScore)
    //    {
    //        highScore = score;
    //        PlayerPrefs.SetInt("highscore", highScore);
    //        PlayerPrefs.Save();
    //        gameOverText.text += "\nNew Highscore";
    //    }
    //}
}
