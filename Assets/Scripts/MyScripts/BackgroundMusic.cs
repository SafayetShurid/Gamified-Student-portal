using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using System;

public class BackgroundMusic : MonoBehaviour
{
    /*private AudioSource _audioSource;
    [SerializeField] private ClassType _classType;
    [SerializeField] private AudioClip _kgClip;
    [SerializeField] private AudioClip _pgClip;
    [SerializeField] private AudioClip _nurseryClip;

    public static BackgroundMusic Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);

        _audioSource = GetComponent<AudioSource>();

       // int classID = Convert.ToInt32(PlayerData.GetClassID());

        *//*if (classID == 1)
        {
            _classType = ClassType.Play;
        }
        else if (classID == 2)
        {
            _classType = ClassType.KG;
        }
        else if (classID == 3)
        {
            _classType = ClassType.KG;
        }*//*


    }

    private void Start()
    {
        //SetBGMusic(_classType);
        _audioSource.Play();
    }

    public void Mute(bool b)
    {
        _audioSource.mute = b;
    }

    public void SetBGMusic(ClassType classType)
    {
        switch (classType)
        {
            case ClassType.Play:
                _audioSource.clip = _pgClip;
                break;
            case ClassType.KG:
                _audioSource.clip = _kgClip;
                break;
            case ClassType.Nursery:
                _audioSource.clip = _nurseryClip;
                break;
        }

    }*/
}