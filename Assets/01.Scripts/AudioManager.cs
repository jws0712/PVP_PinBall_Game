using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AudioSource")]
    [SerializeField] private AudioSource musicSource, sfxSource = null;

    [Header("AudioArray")]
    public SoundData[] musicClipArray, sfxClipArray = null;


    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic(string name)
    {
        SoundData soundDataArray = Array.Find(musicClipArray, x => x.name == name);

        if(soundDataArray == null)
        {
            Debug.Log("Music Not Found");
        }
        else
        {
            musicSource.clip = soundDataArray.clip;
            musicSource.Play();
        }
    }

    public void SFXMusic(string name)
    {
        SoundData soundDataArray = Array.Find(sfxClipArray, x => x.name == name);

        if (soundDataArray == null)
        {
            Debug.Log("Music Not Found");
        }
        else
        {
            musicSource.PlayOneShot(soundDataArray.clip);
        }
    }
}
