using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public abstract class GameManager<T> : MonoBehaviour where T : GameManager<T> 
{
    public static T Instance;

    public string nextScene;
    public EventSystem currentEventSystem;
    public int currentQuestionIndex = 0;
    public bool loadHighFiveInMiddle = false;
    public bool doTransitionAfterQuestion = false;
    public string currentContentString;

    public DateTime startTime;

    protected virtual void Awake()
    {
        Instance = this as T;
       
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        startTime = DateTime.Now;
        //currentContentString = ContentManager.Instance.GetCurrentContentString();
        GenerateNextQuestion();
        PlayAudio(true);  //if true then there will be a starting audio before the question audio
    }

    public abstract void ResetGame();

    public abstract void GenerateNextQuestion();

    public abstract void RightAnswer();

    public virtual void WrongAnswer()
    {
        CommonAudioManager.Instance.PlayAbarchestaKoriClip();
    }

    public virtual void GameOver()
    {
        CommonAudioManager.Instance.PlayRandomTumiPereccho(() => {
           // ContentManager.Instance.CallHistoryAPI(startTime);
          //  ContentManager.Instance.LoadNextContent();

        });
    }

    public abstract void PlayAudio(bool startingAudio);  

    #region PlayHighFiveInMiddle

    public void LoadHighFiveInMiddle()
    {
        StartCoroutine(LoadHighFiveRoutine());
    }

    public virtual void AfterHighFiveFinishes()
    {
        SceneManager.UnloadSceneAsync("HighFiveAdditive2");
        //BackgroundMusic.Instance.Mute(false);
        GenerateNextQuestion();
        PlayAudio(false);

    }

    IEnumerator LoadHighFiveRoutine()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("HighFiveAdditive2", LoadSceneMode.Additive);
        while (!async.isDone)
        {
            yield return null;
        }

        //BackgroundMusic.Instance.Mute(true);
        CommonAudioManager.Instance.Stop();       
        //HighFiveManager.Instance.onVideFinishedInMiddle += AfterHighFiveFinishes;      
    }
    #endregion
}
