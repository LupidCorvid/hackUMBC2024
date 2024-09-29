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
        CanvasUtil.EnableCanvasGroup(LevelSelectMenu);
        CanvasUtil.DisableCanvasGroup(MainMenu);
    }

    public void OpenMainMenu()
    {
        CanvasUtil.EnableCanvasGroup(MainMenu);
        CanvasUtil.DisableCanvasGroup(LevelSelectMenu);
    }



    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

public class CanvasUtil
{
    public static void EnableCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    public static void DisableCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }
}

