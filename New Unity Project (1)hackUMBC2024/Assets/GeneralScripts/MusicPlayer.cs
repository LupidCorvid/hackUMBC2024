using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip currMusic;
    public AudioSource player;

    public static MusicPlayer main;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (main != null)
        {
            Destroy(gameObject);
            return;
        }
        main = this;
        player.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAudio(AudioClip newSource)
    {
        if (newSource != currMusic)
        {
            player.Stop();
            player.clip = newSource;
            currMusic = newSource;
            player.Play();
        }
    }
}
