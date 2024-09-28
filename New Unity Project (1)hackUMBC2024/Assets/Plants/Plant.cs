using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plant : MonoBehaviour
{

    public int growth;
    public int maxGrowth;


    public bool ReachedGoal = false;
    public bool rooted = false;
    public string plantName = "NoPlant"; //NoPlant, Helicopter, Boat, 
    public bool isHeld = false;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ReachedGoal && !rooted)
        {
            if (rb.velocity.magnitude <= .5f)
                Root();
        }
    }

    public virtual void Grow()
    {

    }

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
        //rb.transform = GameObject.FindGameObjectWithTag("Player").
    }

    public virtual void OnPickedUp()
    {

    }

    public virtual void OnLetGo()
    {

    }
}
