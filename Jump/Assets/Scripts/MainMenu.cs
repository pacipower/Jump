using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject highscoreTableUI;
    public Text menuText;
    private int highscore;
    string playerName;
    bool isGrounded;
    public InputField inputField;



    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("highscoreTable");
        Time.timeScale = 1;
        isGrounded = false;
        inputField.characterLimit = 10;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        playerName = PlayerPrefs.GetString("playerName", playerName);
        inputField.text = playerName;
        menuText.text = $"Highscore:\n{highscore}";


    }


    public void PlayerName()
    {
        inputField.text = inputField.text.Replace(" ", "");
        inputField.text = inputField.text.Replace(";", "");
        playerName = inputField.text;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Play()
    {
        PlayerPrefs.SetString("playerName", playerName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HighscoreTable()
    {
        gameObject.SetActive(false);
        highscoreTableUI.SetActive(true);
    }

    public void Back()
    {
        gameObject.SetActive(true);
        highscoreTableUI.SetActive(false);
    }
}
