using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int eventID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<playerMovement>() != null || collision.GetComponent<Plant>() != null)
            LevelManager.main.ButtonTrigger?.Invoke(eventID, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<playerMovement>() != null || collision.GetComponent<Plant>() != null)
            LevelManager.main.ButtonTrigger?.Invoke(eventID, false);
    }
}
