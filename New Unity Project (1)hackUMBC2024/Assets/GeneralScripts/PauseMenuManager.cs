using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public bool paused;

    public CanvasGroup group;

    public static PauseMenuManager main;

    public bool canPause = true;


    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Unpause();
            else if (canPause)
                Pause();
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    public void Unpause()
    {
        paused = false;
        Time.timeScale = 1;
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
