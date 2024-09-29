using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int eventID;
    int pressing = 0;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.Play("btnOff");
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing == 1) anim.Play("btnOn");
        else anim.Play("btnOff");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>() != null || collision.GetComponent<Plant>() != null)
        {
            if(pressing == 0)
                LevelManager.main.ButtonTrigger?.Invoke(eventID, true);
            pressing++;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>() != null || collision.GetComponent<Plant>() != null)
        {
            pressing--;
            if (pressing == 0)
                LevelManager.main.ButtonTrigger?.Invoke(eventID, false);
        }
    }
}
