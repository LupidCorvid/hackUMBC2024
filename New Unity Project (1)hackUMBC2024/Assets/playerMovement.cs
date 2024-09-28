using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = .25f;
    float maxSpeed = 1;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        inputChecker();
    }

    void inputChecker()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x >= maxSpeed) rb.velocity = new Vector2(-maxSpeed, 0);
            else rb.velocity += new Vector2(-speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x >= maxSpeed) rb.velocity = new Vector2(maxSpeed, 0);
            else rb.velocity += new Vector2(speed, 0);
        }
    }
}
