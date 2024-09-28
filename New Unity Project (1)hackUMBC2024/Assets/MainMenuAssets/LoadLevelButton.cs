using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{

    public string sceneName;

    public TMPro.TextMeshProUGUI NumberLabel;


    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
        //SceneManager.UnloadSceneAsync("MainMenu");
    }
}
