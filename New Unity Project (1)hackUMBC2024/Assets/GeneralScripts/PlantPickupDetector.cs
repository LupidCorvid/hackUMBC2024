using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickupDetector : MonoBehaviour
{
    public List<Plant> plantsInRange = new List<Plant>();

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
        Plant hitPlant = collision.GetComponent<Plant>();
        if (hitPlant != null)
            plantsInRange.Add(hitPlant);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Plant hitPlant = collision.GetComponent<Plant>();
        if (hitPlant != null && plantsInRange.Contains(hitPlant))
            plantsInRange.Remove(hitPlant);
    }
}
