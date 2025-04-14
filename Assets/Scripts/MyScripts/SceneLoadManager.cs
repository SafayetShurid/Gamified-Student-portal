using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Base;

public class SceneLoadManager : Singleton<SceneLoadManager>
{


    public void LoadSceneByName(string name)
    {
       
        SceneManager.LoadScene(name);
    }


    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadSceneByNameAsync(string name)
    {
        StartCoroutine(StartLoad(name));
    }

    public void SetSceneInPlayerPref(string sceneName)
    {
        if (sceneName=="Library")
        {
            //PlayerPrefs.DeleteKey(PlayerData.CURRENT_ACTIVE_DOMAIN);
        }
       // PlayerPrefs.SetString(PlayerData.LAST_SCENE_NAME, sceneName);
    }

    IEnumerator StartLoad(string name)
    {
        LoadingScreenManager.Instance.Load(LoadingScreenAnimal.Random);
        yield return new WaitForSeconds(1f);
        Debug.Log(name);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        //operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            //if(BackgroundMusic.Instance!=null)
           // BackgroundMusic.Instance.Mute(false);
            yield return null;
           
        }


    }
    
}
