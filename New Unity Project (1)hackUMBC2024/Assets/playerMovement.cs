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
    public float helicopterSpeed = 16;
    public float maxSpeed = 8f;
    public bool isJumping = false;
    public bool isFalling = false;

    public Plant currPlant;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        currPlant = null;
    }

    public void Update()
    {
        inputChecker();
    }

    void FixedUpdate()
    {
        
    }

    void inputChecker()
    {
        Vector2 inputMovement = Vector2.zero;

        //Drop plant
        if (Input.GetKeyDown(KeyCode.S))
        {
            currPlant.isHeld = false;
            currPlant = null;
        }

        //Jumping/Helicopter
        if (currPlant?.plantName == "Helicopter")
        {
            //Up
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                inputMovement += new Vector2(0, helicopterSpeed);
                isJumping = true;
            }
            //Down/Fall
            if (Input.GetKeyUp(KeyCode.W) && !isFalling && isJumping)
            {
                isFalling = true;
                if (rb.velocity.y > 0)
                    inputMovement = new Vector2(0, -(rb.velocity.y / 4));
            }
        }
        else
        {
            //Regular Jumping
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                anim.Play("jumpUp");
                inputMovement += new Vector2(0, jumpSpeed);
                isJumping = true;
            }
            //Half the upward velocity when the player lets go of the jump key
            if (Input.GetKeyUp(KeyCode.W) && !isFalling && isJumping)
            {
                anim.Play("fall");
                isFalling = true;
                if (rb.velocity.y > 0)
                    inputMovement = new Vector2(0, -(rb.velocity.y / 2));
            }
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

    void pickUpPlant(Plant target)
    {
        target.isHeld = true;
        currPlant = target;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Reset jumping
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isFalling = false;
        }

        //Pick up plant
        if (collision.gameObject.CompareTag("Plant"))
        {
            if (Input.GetKeyDown(KeyCode.S)) pickUpPlant(collision.gameObject.GetComponent<Plant>());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Pick up plant
        if (collision.gameObject.CompareTag("Plant"))
        {
            if(currPlant == null)
                if (Input.GetKeyDown(KeyCode.S)) pickUpPlant(collision.gameObject.GetComponent<Plant>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
            isJumping = true;
            anim.Play("fall");
        }
    }
}
