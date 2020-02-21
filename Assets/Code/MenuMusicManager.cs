using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public static AudioSource titleMusic;
    public static bool playingMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!playingMusic)
        {
            titleMusic = GameObject.Find("Title").GetComponent<AudioSource>();
            titleMusic.Play();
            DontDestroyOnLoad(titleMusic);
            playingMusic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopTitle()
    {
        titleMusic.Stop();
    }
}
