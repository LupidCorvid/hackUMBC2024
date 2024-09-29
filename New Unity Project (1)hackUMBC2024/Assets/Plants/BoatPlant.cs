using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPlant : Plant
{

    public override void followPlayer()
    {
        Vector2 newLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        newLocation.y -= 1;
        rb.velocity = Vector2.zero;
        transform.position = newLocation;
    }
}
