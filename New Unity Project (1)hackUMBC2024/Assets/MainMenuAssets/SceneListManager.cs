using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneListManager : MonoBehaviour
{
    public List<string> LevelSceneNames = new List<string>();
    public GameObject LevelChangeButtonPrefab;

    private void Start()
    {
        for (int i = 0; i < LevelSceneNames.Count; i++)
        {
            LoadLevelButton addedButton = Instantiate(LevelChangeButtonPrefab, transform).GetComponent<LoadLevelButton>();
            addedButton.sceneName = LevelSceneNames[i];
            addedButton.NumberLabel.text = "" + (i+1);
        }

    }
}
