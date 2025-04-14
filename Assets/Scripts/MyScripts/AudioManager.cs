using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;



public class AudioManager : Singleton<AudioManager>
{


    public enum AUDIOSOURCE
    {
        audioSource1, audioSource2, audioSource3, audioSource4
    }

    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;
    [SerializeField] private AudioSource audioSource4;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Play(AudioClip clip, AUDIOSOURCE source)
    {
        switch (source)
        {
            case AUDIOSOURCE.audioSource1:
                if (!audioSource1.isPlaying)
                {
                    audioSource1.PlayOneShot(clip);
                }
                break;
            case AUDIOSOURCE.audioSource2:
                if (!audioSource2.isPlaying)
                {
                    audioSource2.PlayOneShot(clip);
                }
                break;
            case AUDIOSOURCE.audioSource3:
                if (!audioSource3.isPlaying)
                {
                    audioSource3.PlayOneShot(clip);
                }
                break;
            case AUDIOSOURCE.audioSource4:
                if (!audioSource4.isPlaying)
                {
                    audioSource4.PlayOneShot(clip);
                }
                break;
        }

    }
}