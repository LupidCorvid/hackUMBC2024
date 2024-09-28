using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    [SerializeField] PhysicsMaterial2D frictionNotMoving;
    [SerializeField] PhysicsMaterial2D frictionMoving;
    public float acceleration = 2;
    public float jumpSpeed = 8;
    public float maxSpeed = 8f;
    bool isJumping = false;
    bool isFalling = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        inputChecker();
    }

    void inputChecker()
    {
        Vector2 inputMovement = Vector2.zero;
        
        //Jumping
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            anim.Play("jumpUp");
            inputMovement += new Vector2(0, jumpSpeed);
            isJumping = true;
            sr.color = Color.red;
        }
        //Half the upward velocity when the player lets go of the jump key
        if (Input.GetKeyUp(KeyCode.W) && !isFalling)
        {
            anim.Play("fall");
            isFalling = true;
            inputMovement = new Vector2(0, (rb.velocity.y/2));
            sr.color = Color.yellow;
        }

        //Sideways movement
        if (Input.GetKey(KeyCode.A))
        {
            anim.Play("walk");
            if (rb.velocity.x > -maxSpeed) inputMovement += new Vector2(-acceleration, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < maxSpeed) inputMovement += new Vector2(acceleration, 0);
        }
        if (inputMovement == Vector2.zero)
        {
            anim.Play("idle");
            rb.sharedMaterial = frictionNotMoving;
        }
        else
            rb.sharedMaterial = frictionMoving;

        rb.velocity += inputMovement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isFalling = false;
            sr.color = Color.green;
        }
    }
}
