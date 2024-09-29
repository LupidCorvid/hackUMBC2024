using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlant : Plant
{
    public GameObject GrownPlant;
    public GameObject RegPlant;

    public override void Grow()
    {
        base.Grow();
        GrownPlant.SetActive(true);
        RegPlant.SetActive(false);
    }
}
