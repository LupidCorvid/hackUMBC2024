using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlant : Plant
{
    public GameObject GrownPlant;
    public Collider2D cldr;

    public override void Grow()
    {
        base.Grow();
        cldr.enabled = true;
        Debug.Log("grown");
    }
}
