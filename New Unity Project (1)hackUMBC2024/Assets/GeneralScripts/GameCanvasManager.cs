using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    public CanvasGroup WinScreen;
    public CanvasGroup PauseScreen;
    public CanvasGroup LoseScreen;

    public static GameCanvasManager main;
    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLoseScreen()
    {
        CanvasUtil.EnableCanvasGroup(LoseScreen);
        Time.timeScale = 0;
    }
}
