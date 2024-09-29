using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<playerMovement>() != null)
        {
            if (collision.gameObject.GetComponent<playerMovement>().currPlant?.plantName != "Boat")
            {
                GameCanvasManager.main.OpenLoseScreen();
                collision.gameObject.GetComponent<playerMovement>().Die();
            }
        }
    }
}
