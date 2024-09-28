using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] PhysicsMaterial2D frictionNotMoving;
    [SerializeField] PhysicsMaterial2D frictionMoving;
    public float acceleration = 2;
    public float jumpSpeed = 5;
    public float maxSpeed = 8f;
    bool isJumping = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        print(rb.velocity.x);
        inputChecker();
    }

    void inputChecker()
    {
        Vector2 inputMovement = Vector2.zero;
        
        //Jumping
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping) 
            {
                inputMovement += new Vector2(0, jumpSpeed);
                isJumping = true;
            }
        }
        //Half the upward velocity when the player lets go of the jump key
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space)) && isJumping)
        {
            inputMovement = new Vector2(0, (.5f*jumpSpeed));
        }

        //Sideways movement
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -maxSpeed) inputMovement += new Vector2(-acceleration, rb.velocity.y);
            //if (rb.velocity.x <= -maxSpeed) inputMovement = new Vector2(-maxSpeed, 0);
            //else inputMovement += new Vector2(-acceleration, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < maxSpeed) inputMovement += new Vector2(acceleration, rb.velocity.y);
            //if (rb.velocity.x >= maxSpeed) inputMovement = new Vector2(maxSpeed, 0);
            //else inputMovement += new Vector2(acceleration, 0);
        }
        if (inputMovement == Vector2.zero)
            rb.sharedMaterial = frictionNotMoving;
        else
            rb.sharedMaterial = frictionMoving;

        rb.velocity += inputMovement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isJumping = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
