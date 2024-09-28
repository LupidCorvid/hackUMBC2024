using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id;
    public Collider2D cldr;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.main.ButtonTrigger += buttonTriggered;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonTriggered(int id, bool state)
    {
        if (cldr == null)
            return;

        if(this.id == id)
        {
            if (state)
                cldr.enabled = false;
            else
                cldr.enabled = true;
        }
    }
}
