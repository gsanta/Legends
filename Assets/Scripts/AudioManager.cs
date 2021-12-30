using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] SFX, backgroundMusic;

    public static AudioManager instance;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayBackgroundMusic(5);
        }
    }

    public void PlaySFX(int soundIndex)
    {
        if (soundIndex < SFX.Length)
        {
            SFX[soundIndex].Play();
        }
    }

    public void PlayBackgroundMusic(int soundIndex)
    {
        StopMusic();
        if (soundIndex < backgroundMusic.Length)
        {
            backgroundMusic[soundIndex].Play();
        }
    }

    private void StopMusic()
    {
        foreach (var song in backgroundMusic)
        {
            song.Stop();
        }
    }
}
