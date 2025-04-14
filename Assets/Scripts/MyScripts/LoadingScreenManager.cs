using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using System;
using Random = UnityEngine.Random;

public enum LoadingScreenAnimal
{
    Random,Chicken,Ele
}

public class LoadingScreenManager : Singleton<LoadingScreenManager>
{
    [SerializeField] private GameObject[] _loadingObject;

    private GameObject _currentLoadingScreen;

    public void StartLoading(Action callback)
    {
        StartCoroutine(StartLoadingRoutine(callback));
    }

    public IEnumerator StartLoadingRoutine(Action callback)
    {
        int rand = Random.Range(0, _loadingObject.Length);
        _loadingObject[rand].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _loadingObject[rand].SetActive(false);
        callback();
    }

    public void Load(LoadingScreenAnimal loadingScreenAnimal)
    {
        switch ((loadingScreenAnimal))
       
        {
            case LoadingScreenAnimal.Random:
                int rand = Random.Range(0, _loadingObject.Length);
                _currentLoadingScreen = _loadingObject[rand];
                break;           
            case LoadingScreenAnimal.Chicken:
                _currentLoadingScreen = _loadingObject[0];
                break;
            case LoadingScreenAnimal.Ele:
                _currentLoadingScreen = _loadingObject[1];
                break;
        };

        _currentLoadingScreen.SetActive(true);
    }

    public void UnLoad()
    {
        if (_currentLoadingScreen != null)
        {
            _currentLoadingScreen.SetActive(false);
        }
       
    }


}
