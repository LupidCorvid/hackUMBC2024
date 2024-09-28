using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] PhysicsMaterial2D frictionNotMoving;
    [SerializeField] PhysicsMaterial2D frictionMoving;
    float acceleration = .5f;
    float jumpSpeed = 2;
    float maxSpeed = 4;
    bool isJumping = false;

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
        Vector2 inputMovement = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!isJumping)
            {
                inputMovement += new Vector2(0, jumpSpeed);
                isJumping = true;
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (inputMovement.x <= -maxSpeed) inputMovement = new Vector2(-maxSpeed, 0);
            else inputMovement += new Vector2(-acceleration, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (inputMovement.x >= maxSpeed) inputMovement = new Vector2(maxSpeed, 0);
            else inputMovement += new Vector2(acceleration, 0);
        }
        if (inputMovement == Vector2.zero)
            rb.sharedMaterial = frictionNotMoving;
        else
            rb.sharedMaterial = frictionMoving;

        rb.velocity += inputMovement;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
