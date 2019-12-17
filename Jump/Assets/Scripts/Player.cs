using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody2D player;
    float move, speed;
    bool isGrounded;
    private bool isAlive;
    private bool left;
    private bool right;
    [SerializeField]
    private GameObject gameoverUI;
    [SerializeField]
    private GameObject gameRunningUI;
    [SerializeField]
    private GameObject gamePausedUI;
    public Text gameOverText;
    public Text pauseScoreText;

    public Animator animator;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        if (Level.landscape)
        {
            speed = 1;
        }
        else speed = 0.5f;

        Time.timeScale = 1;
        player = GetComponent<Rigidbody2D>();
        isAlive=true;
        left = false;
        right = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Ground" || other.gameObject.tag == "Platform")
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
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
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        Time.timeScale = 0;
        UpdateGameOverText();
        isAlive = false;
        if (Score.score>Score.highscoreBottom)
        {
            Score.addScore = true;
        }
        Destroy(gameObject);
        gameoverUI.SetActive(true);
        gameRunningUI.SetActive(false);
    }

    public void UpdateGameOverText()
    {

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

        

        if (Time.timeScale!=0)
        {
            if (right)
            {
                move = 0.05f;
                spriteRenderer.flipX = false;
            }
            else if (left)
            {
                move = -0.05f;
                spriteRenderer.flipX = true;
                
            }
            else move = 0;
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("move", Mathf.Abs(move));


    }

    public void Jump()
    {
        if (isGrounded && Time.timeScale != 0)
        {
            player.AddForce(new Vector3(0, 8.5f, 0), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    public void Right()
    {
        right = true;
    }

    public void Left()
    {
        left = true;
    }

    public void Stop()
    {
        right = false;
        left = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScoreText.text = $"Highscore:\n{Score.highScore}\nCurrent Score:\n{Score.score}";
        gamePausedUI.SetActive(true);
        gameRunningUI.SetActive(false);
    }

    public void Resume()
    {
        gamePausedUI.SetActive(false);
        gameRunningUI.SetActive(true);
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * move*speed;
        if (transform.position.y<Camera.minPosition-7)
        {
            PlayerDeath();
        }
    }
}
