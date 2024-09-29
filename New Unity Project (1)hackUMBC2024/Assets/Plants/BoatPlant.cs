using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPlant : Plant
{

    public override void followPlayer()
    {
        Vector2 newLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(grown)
            newLocation.y -= .5f;
        else
            newLocation.y += 1;
        rb.velocity = Vector2.zero;
        transform.position = newLocation;
    }

    public override void OnLetGo()
    {
        
        if (grown)
            transform.position += Vector3.up * 1f;
        base.OnLetGo();
    }
}
