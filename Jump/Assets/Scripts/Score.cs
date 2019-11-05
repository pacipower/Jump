using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static TMP_Text ScoreBoard;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        ScoreBoard = GetComponent<TMP_Text>();
    }

    public static void UpdateScore()
    {
        ScoreBoard.text = "Score:\n"+score;
    }
}
