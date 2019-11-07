using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody2D player;
    float move;
    bool isGrounded;
    private bool isAlive;
    [SerializeField]
    private GameObject gameoverUI;
    [SerializeField]
    private GameObject quitButton;
    public Text gameOverText;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        player = GetComponent<Rigidbody2D>();
        isAlive=true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Ground" || other.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            //transform.position = new Vector3(0, -3.59f, 0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Level.EndGame();
            Time.timeScale = 0;
            UpdateGameOverText();
            isAlive = false;
            gameoverUI.SetActive(true);
            quitButton.SetActive(false);
            //Level.EndGame2();
            //Destroy(gameObject);
        }
    }

    public void UpdateGameOverText()
    {
        //Text gameOverText = gameoverUI.GetComponent<Text>();

        gameOverText.text = $"Game Over\nYour Score:\n{Score.score}";
        if (Score.score > Score.highScore)
        {
            Score.highScore = Score.score;
            PlayerPrefs.SetInt("highscore", Score.highScore);
            PlayerPrefs.Save();
            gameOverText.text += "\nNew Highscore";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {


            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
            {
                player.AddForce(new Vector3(0, 10, 0), ForceMode2D.Impulse);
                isGrounded = false;
            }

            if (Input.GetAxis("Horizontal") < -0.1f)
            {
                move = -0.05f;
            }
            else if (Input.GetAxis("Horizontal") > 0.1f)
            {
                move = 0.05f;
            }
            else
            {
                move = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
