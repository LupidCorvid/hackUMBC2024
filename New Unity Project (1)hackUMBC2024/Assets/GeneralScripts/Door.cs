using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id;
    public Collider2D cldr;
    Animator anim;
    public bool wasOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.main.ButtonTrigger += buttonTriggered;
        anim = gameObject.GetComponent<Animator>();
        anim.Play("doorClose");
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
            {
                wasOpen = true;
                cldr.enabled = false;
                anim.Play("doorOpen");
            }
            else
            {
                cldr.enabled = true;
                if (wasOpen)
                {
                    anim.Play("doorClose");
                    wasOpen = false;
                }
            }
                
        }
    }
}
