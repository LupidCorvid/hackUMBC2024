using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public CanvasGroup LevelSelectMenu;
    public CanvasGroup MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLevelSelect()
    {
        EnableCanvasGroup(LevelSelectMenu);
        DisableCanvasGroup(MainMenu);
    }

    public void OpenMainMenu()
    {
        EnableCanvasGroup(MainMenu);
        DisableCanvasGroup(LevelSelectMenu);
    }

    public void EnableCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    public void DisableCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
