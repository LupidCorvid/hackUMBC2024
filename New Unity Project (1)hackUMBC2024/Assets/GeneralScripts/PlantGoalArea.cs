using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGoalArea : MonoBehaviour
{
    public bool AllPlantsSettled = false;

    public List<Plant> GatheredPlants = new List<Plant>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlantsSettled();
    }

    public void CheckPlantsSettled()
    {
        foreach (Plant plant in GatheredPlants)
        {
            if (plant.GetComponent<Rigidbody2D>().velocity.magnitude > .05f)
            { 
                AllPlantsSettled = false;
                return;
            }
        }
        AllPlantsSettled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Plant enteringPlant = collision.GetComponent<Plant>();

        if (enteringPlant != null)
            GatheredPlants.Add(enteringPlant);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Plant leavingPlant = collision.GetComponent<Plant>();

        if (leavingPlant != null)
            GatheredPlants.Remove(leavingPlant);
    }
}
