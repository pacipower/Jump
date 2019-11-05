using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    float x, y, move;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        if (x < 0)
        {
            move = 0.1f;
        }
        else
            move = -0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            transform.position = new Vector3(x, y, 0);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
