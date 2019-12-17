using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float move, speed;
    bool isReached;
    int count;


    // Start is called before the first frame update
    void Start()
    {
        if (Level.landscape)
        {
            speed = 1;
        }
        else speed = 0.5f;

        count = Mathf.RoundToInt((transform.position.y+1)/3.5f);
        isReached = false;
        move = 0.05f*speed+count*0.001f*speed;
        if (((transform.position.y+Level.offset)/Level.elevation)%2==1)
        {
            move = -move;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((transform.position.y-Level.elevation+Level.offset+7)%14==0)
        {
            if (other.gameObject.tag == "Wall")
            {
                move = -move;
            }
        }
        else
        {
            if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2")
            {
                move = -move;
            }
        }
        

        if (other.gameObject.tag=="Player" && !isReached && other.gameObject.transform.position.y>transform.position.y)
        {
            isReached = true;
            Score.score++;
            Score.UpdateScore();
            if (transform.position.y>Camera.minPosition)
            {
                Camera.minPosition = transform.position.y-1;
                if ((Camera.minPosition-2.5f+1)%14==0)
                {
                    Level.needNewLevel = true;
                }
            }
        }
    }

    

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
