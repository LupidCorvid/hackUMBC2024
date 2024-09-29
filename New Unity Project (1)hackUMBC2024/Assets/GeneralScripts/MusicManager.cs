using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip music;


    // Start is called before the first frame update
    void Start()
    {
        MusicPlayer.main?.ChangeAudio(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
