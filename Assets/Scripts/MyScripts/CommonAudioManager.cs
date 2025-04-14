using Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CommonAudioManager : Singleton<CommonAudioManager>
{
   
    public SoundClip[] instructionAudioClips;
    public SoundClip[] startingAudioClips;
    public SoundClip commonQuestionClip;
  

    [Header("Common")]
    public AudioClip[] tumiPerecchoclips;
    public AudioClip abarChetaKoriClip; 
    
    [Header("Extra")]
    public AudioClip[] extraAudioclips;

    [Header("ClickEffects")]
    public SoundClip[] clickClips;

    public float repeatTime;

    private int currentInstructionCounter = -1;
    private AudioSource _audioSource;
    private AudioSource _audioSource2;

    private AudioClip currentAudioClip;
    private bool startingCompleted = false;

    public delegate void OnInstructionFinish();
    public event OnInstructionFinish onInstructionFinish;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource2 = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip, Action callback = null,bool isLoop = false,float loopTime = 10, bool playCommon = false)
    {
        StopAllCoroutines();
        _audioSource.Stop();
        _audioSource.clip = clip;

        if (!isLoop)
        {
            StartCoroutine(PlayRoutine(callback));
        }
        else
        {
            StartCoroutine(PlayLoopRoutine(clip,callback,loopTime));
        }
       
    }

   

    public void Stop()
    {
        StopAllCoroutines();
        _audioSource.Stop();
    }

    IEnumerator PlayRoutine(Action callback)
    {
        _audioSource.Play();
        yield return new WaitUntil(() => !_audioSource.isPlaying);
        callback?.Invoke();
    }

    IEnumerator PlayLoopRoutine(AudioClip clip, Action callback, float loopTime)
    {
        while (true)
        {           
            if (_audioSource.isPlaying)
            {
                yield return new WaitUntil(() => !_audioSource.isPlaying);
            }

            if (commonQuestionClip != null)
            {
                _audioSource.clip = commonQuestionClip.audioclip;
                _audioSource.Play();
                yield return new WaitUntil(() => !_audioSource.isPlaying);
            }

            _audioSource.clip = clip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);

            

            callback?.Invoke();
            yield return new WaitForSeconds(loopTime);
        }
    }

    public void PlayRandomTumiPereccho(Action callback = null)
    {
        StopAllCoroutines();
        _audioSource.Stop();
        _audioSource.clip = tumiPerecchoclips[Random.Range(0, tumiPerecchoclips.Length)];
        _audioSource.Play();      
        StartCoroutine(AfterAudioFinishes(callback));

    }

    public void PlayAbarchestaKoriClip()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = abarChetaKoriClip;
            _audioSource.Play();
            //StartCoroutine(AfterAudioFinishes(callback));
        }
    }

    IEnumerator AfterAudioFinishes(Action callback)
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        callback?.Invoke();
        
    }

    public void Mute(bool b)
    {
        
    }

    public void PlayStartingAudio()
    {
        StartCoroutine(PlayStartingAudioRoutine());
    }

    IEnumerator PlayStartingAudioRoutine()
    {
        for (int i = 0; i < startingAudioClips.Length; i++)
        {
            _audioSource.clip = startingAudioClips[i].audioclip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);
        }
        startingCompleted = true;

        if (instructionAudioClips.Length > 0)
        {
            PlayNextInstructionAudio();
        }
        else if (commonQuestionClip != null)
        {
            PlayCommonAudio();
            Debug.Log("call hoi to vai");
        }       
       
    }

    public void PlayStartingAudio(Action callback)
    {
        StartCoroutine(PlayStartingAudioRoutine2(callback));
    }

    IEnumerator PlayStartingAudioRoutine2(Action callback)
    {
        for (int i = 0; i < startingAudioClips.Length; i++)
        {
            _audioSource.clip = startingAudioClips[i].audioclip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);
        }
        startingCompleted = true;
        callback?.Invoke();
    }

   

    public void PlayAfterCertainSeconds(float time,Action callback)
    {
        StartCoroutine(PlayAfterCertainSecondsRoutine(time, callback));
    }

    IEnumerator PlayAfterCertainSecondsRoutine(float time,Action callback)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (_audioSource.isPlaying)
            {
                yield return new WaitUntil(() => !_audioSource.isPlaying);
            }
            callback();
        }
    }

    public void PlayNextInstructionAudio()
    {
        if (startingCompleted)
        {
            currentInstructionCounter++;
        }

        else
        {
            currentInstructionCounter += 2;
            startingCompleted = true;
        }

      
        if(currentInstructionCounter >= instructionAudioClips.Length)
        {
            Debug.Log("Game Over");
        }
        else
        {
            currentAudioClip = instructionAudioClips[currentInstructionCounter].audioclip;
            _audioSource.clip = currentAudioClip;
            StopAllCoroutines();
            StartCoroutine(PlayInstructionAudioRoutine());
        }
      
    }

    IEnumerator PlayInstructionAudioRoutine()
    {
        while (true)
        {
            if (_audioSource.isPlaying)
            {
                yield return new WaitUntil(() => !_audioSource.isPlaying);
            }
            _audioSource.clip = commonQuestionClip.audioclip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);
            _audioSource.clip = currentAudioClip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);
            onInstructionFinish?.Invoke();
            yield return new WaitForSeconds(repeatTime);
           
        }       
    }

    public void PlayCommonAudioAfterCertainSeconds()
    {
        StopAllCoroutines();
        _audioSource.Stop();       
        StartCoroutine(PlayCommonAudioAfterRoutine());

    }

    IEnumerator PlayCommonAudioAfterRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(repeatTime);
            if (_audioSource.isPlaying)
            {
                yield return new WaitUntil(() => !_audioSource.isPlaying);
            }
           
            _audioSource.clip = commonQuestionClip.audioclip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);           
 
        }
    }

    public void PlayCommonAudio()
    {
        StopAllCoroutines();
        _audioSource.Stop();
        StartCoroutine(PlayCommonAudioRoutine());

    }

    IEnumerator PlayCommonAudioRoutine()
    {
        while (true)
        {
           
            if (_audioSource.isPlaying)
            {
                yield return new WaitUntil(() => !_audioSource.isPlaying);
            }

            _audioSource.clip = commonQuestionClip.audioclip;
            _audioSource.Play();
            yield return new WaitUntil(() => !_audioSource.isPlaying);
            yield return new WaitForSeconds(repeatTime);

        }
    }

    public void PlayClickEffects()
    {
        _audioSource2.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)].audioclip);
    }

    public void PlayClickEffect(int index)
    {
        _audioSource2.PlayOneShot(clickClips[index].audioclip);
    }

    public void ResetRepeatTime()
    {
        repeatTime = 10;
    }
}

[System.Serializable]
public class SoundClip
{
    public string name;
    public AudioClip audioclip;
} 
