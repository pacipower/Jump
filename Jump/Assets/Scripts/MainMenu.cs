using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerMenu;
    public Text menuText;
    private int highscore;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        menuText.text = $"Highscore:\n{highscore}";
    }

    

    // Update is called once per frame
    void Update()
    {
        if (playerMenu.transform.position.y < 1.7549998)
        {
            isGrounded=true;
        }

        
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            isGrounded = false;
            playerMenu.AddForce(new Vector3(0, 8.5f, 0), ForceMode2D.Impulse);
        }
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
