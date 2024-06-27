using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public AudioSource[] sources;

    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            sources = GetComponentsInChildren<AudioSource>();
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    public void SoundAllMute()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].mute = true;
        }
    }

    public void SoundAllOn()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].mute = false;
        }
    }

    public void stopSound(string soundName)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            if (sources[i].gameObject.name.CompareTo(soundName) == 0)
            {
                sources[i].Stop();
            }
        }
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            if (sources[i].gameObject.name.CompareTo(soundName) == 0)
            {
                sources[i].Play();
            }
        }
    }
}
