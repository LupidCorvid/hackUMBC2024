using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Plant> plants = new List<Plant>();
    bool finishedLevel;

    public static LevelManager main;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plantFinished()
    {
        
    }

    public void plantSettled()
    {
        checkForWin();
    }

    public void checkForWin()
    {
        foreach(Plant plant in plants)
        {
            if (!plant.rooted)
                return;
        }

        FinishLevel();
    }

    public void FinishLevel()
    {
        finishedLevel = true;
        Debug.Log("Winner");
        WinScreenManager.main.OpenWinScreen();

    }
    
}
