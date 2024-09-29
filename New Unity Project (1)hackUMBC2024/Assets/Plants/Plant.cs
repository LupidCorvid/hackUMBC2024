using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plant : MonoBehaviour
{

    public bool grown = false;


    public bool ReachedGoal = false;
    public bool rooted = false;
    public string plantName = "NoPlant"; //NoPlant, Helicopter, Boat, 
    public bool isHeld = false;

    public Rigidbody2D rb;

    public float settleProgress = 0;
    public float settleTime = 1f;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(ReachedGoal && !rooted)
        //{
        //    if (rb.velocity.magnitude <= .5f)
        //        Root();
        //}

        if (isHeld)
        {
            followPlayer();
            //startSettlingTime = Time.time;
        }
        else
        {
            if (rb.velocity == Vector2.zero && !grown && !isHeld && ReachedGoal)
            {
                if (anim != null)
                    anim.SetFloat("Speed", 1/settleTime);

                //if (settleTime + startSettlingTime < Time.time)
                //    Grow();
                settleProgress += Time.deltaTime;
                if (settleProgress > settleTime)
                    Grow();
            }
            else
            {
                //startSettlingTime = Time.time;
                if (anim != null)
                    anim.SetFloat("Speed", 0);

            }
        }
    }

    public virtual void Grow()
    {
        Debug.Log("Grow");
        grown = true;
    }

    //Unused
    public virtual void Root()
    {
        rooted = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        LevelManager.main.plantSettled();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlantGoalArea>() != null)
            ReachedGoal = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlantGoalArea>() != null)
            ReachedGoal = false;
    }

    public void followPlayer()
    {
        Vector2 newLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        newLocation.y += 1;
        rb.velocity = Vector2.zero;
        transform.position = newLocation;
    }

    public virtual void OnPickedUp()
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerLayer");
        if (anim != null)
            anim.SetFloat("Speed", 0);
        //grown = false;
    }

    public virtual void OnLetGo()
    {
        gameObject.layer = LayerMask.NameToLayer("PlantLayer");
    }
}
