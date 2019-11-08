using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float y,z;
    private float move;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
        z = transform.position.z;
        move = -0.01f / z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<-14)
        {
            transform.position = new Vector3(14, transform.parent.position.y-1+y, z);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * move;
    }
}
