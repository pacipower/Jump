using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float move;
    bool isReached;
    // Start is called before the first frame update
    void Start()
    {
        isReached = false;
        if ((transform.position.y/4.5)%2==1)
        {
            move = -0.05f;
        }
        else
        move = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Wall")
        {
            move = -move;
        }

        if (other.gameObject.tag=="Player" && !isReached)
        {
            isReached = true;
            Score.score++;
            Score.UpdateScore();
        }
    }

    

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
