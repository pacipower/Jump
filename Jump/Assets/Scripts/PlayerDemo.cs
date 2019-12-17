using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : MonoBehaviour
{

    Rigidbody2D player;
    float move;
    bool isGrounded;
    public Animator animator;
    bool isFacingRight;
    public SpriteRenderer spriteRenderer;

    float x, lastX;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        x = transform.position.x;
        lastX = -1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        

            if (x>lastX)
            {
                move = 0.05f;
                spriteRenderer.flipX = false;
            }
            else 
            {
                move = -0.05f;
                spriteRenderer.flipX = true;

            }

        if (isGrounded)
        {
            player.AddForce(new Vector3(0, 8.5f, 0), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("move", Mathf.Abs(move));


        lastX = x;
        x = transform.position.x;

    }
    

    

    
}
