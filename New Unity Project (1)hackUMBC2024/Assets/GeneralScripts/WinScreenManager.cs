using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public static WinScreenManager main;
    public CanvasGroup group;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenWinScreen()
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
        PauseMenuManager.main.canPause = false;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
