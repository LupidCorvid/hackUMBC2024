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

    public PlantPickupDetector plantPickupRange;

    public Plant currPlant;

    public AudioClip JumpSound;
    public AudioClip LandSound;
    public AudioClip MoveSound;

    public AudioSource jumpAudio;
    public AudioSource landAudio;
    public AudioSource moveAudio;

    public SpriteRenderer sprite;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        currPlant = null;
        moveAudio.clip = MoveSound;
        moveAudio.loop = true;
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
            if (currPlant != null)
            {
                //currPlant.isHeld = false;
                //currPlant = null;
                dropPlant();
            }
            else
            {
                if (plantPickupRange.plantsInRange.Count > 0)
                    pickUpPlant(plantPickupRange.plantsInRange[0]);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
            Throw();

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
                isJumping = false;
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
                jumpAudio.clip = JumpSound;
                jumpAudio.Play();
                inputMovement += new Vector2(0, jumpSpeed);
                isJumping = true;
            }
            //if(rb.velocity.y < 0)
            //{
            //    anim.Play("fall");
            //    isJumping = false;
            //}
            //if (rb.velocity.y > 0)
            //{
            //    anim.Play("jumpUp");
            //    isJumping = false;
            //}
            //Half the upward velocity when the player lets go of the jump key
            if (Input.GetKeyUp(KeyCode.W) && !isFalling && isJumping)
            {
                anim.Play("fall");
                isJumping = false;
                if (rb.velocity.y > 0)
                    inputMovement = new Vector2(0, -(rb.velocity.y / 2));
            }
        }

        bool xMoveAttempt = false;
        //Sideways movement
        if (Input.GetKey(KeyCode.A))
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("walk") && !isFalling && !isJumping)
                anim.Play("walk");
            if (rb.velocity.x > -maxSpeed) inputMovement += new Vector2(-acceleration, 0) * Time.deltaTime;
            xMoveAttempt = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("walk") && !isFalling && !isJumping)
                anim.Play("walk");
            if (rb.velocity.x < maxSpeed) inputMovement += new Vector2(acceleration, 0) * Time.deltaTime;
            xMoveAttempt = true;
        }
        if (inputMovement == Vector2.zero && !(isFalling || isJumping || xMoveAttempt))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                anim.Play("idle");
            rb.sharedMaterial = frictionNotMoving;
            moveAudio.Pause();
        }
        else
        {
            rb.sharedMaterial = frictionMoving;
            if(!moveAudio.isPlaying)
                moveAudio.Play();
        }

        if (inputMovement.x != 0)
        {
            if (inputMovement.x < 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;
        }

        rb.velocity += inputMovement;
    }

    public void Throw()
    {
        if(currPlant != null)
        {
            Rigidbody2D tempBody = currPlant.rb;
            dropPlant();
            //tempBody.velocity 
            if (sprite.flipX)
                tempBody.velocity += new Vector2(-5, 5);
            else
                tempBody.velocity += new Vector2(5, 5);
        }
    }

    void pickUpPlant(Plant target)
    {
        target.isHeld = true;
        currPlant = target;
        currPlant.OnPickedUp();
    }

    void dropPlant()
    {
        currPlant.rb.velocity = rb.velocity;
        currPlant.OnLetGo();
        currPlant.isHeld = false;
        currPlant = null;
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Reset jumping
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isJumping = false;
    //        isFalling = false;
    //    }

    //    //Pick up plant
    //    if (collision.gameObject.CompareTag("Plant"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.S)) pickUpPlant(collision.gameObject.GetComponent<Plant>());
    //    }
    //}
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    //Pick up plant
    //    if (collision.gameObject.CompareTag("Plant"))
    //    {
    //        if(currPlant == null)
    //            if (Input.GetKeyDown(KeyCode.S)) pickUpPlant(collision.gameObject.GetComponent<Plant>());
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isFalling = true;
    //        isJumping = true;
    //        anim.Play("fall");
    //    }
    //}

    public void Land()
    {
        
        isJumping = false;
        isFalling = false;
        landAudio.clip = LandSound;
        landAudio.Play();
    }

    public void Fall()
    {
        
        isFalling = true;
        isJumping = true;
        anim.Play("fall");
    }
}
