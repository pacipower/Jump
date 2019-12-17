using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    float x, y, move, speed;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        if (Level.landscape)
        {
            speed = 1;
        }
        else speed = 0.5f;

        x = transform.position.x;
        y = transform.position.y;
        count = Mathf.RoundToInt((y - 0.75f) / 3.5f);
        move = 0.1f*speed+count*0.002f*speed;
        if (x > 0)
        {
            move = -move;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2")
        {
            transform.position = new Vector3(x, y, 0);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
