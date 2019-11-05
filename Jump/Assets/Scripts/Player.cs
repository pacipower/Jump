using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D player;
    float move;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
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

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
