using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllerScript : MonoBehaviour
{
    [SerializeField] private AudioSource MusicPlayer;
    private AudioClip Current;
    public void PlayMusic(AudioClip Mp3)
    {
        MusicPlayer.clip = Mp3;
        Current = Mp3;
        MusicPlayer.Play();
    }

    public void PauseMusic()
    {
        MusicPlayer.Stop();
    }
}
