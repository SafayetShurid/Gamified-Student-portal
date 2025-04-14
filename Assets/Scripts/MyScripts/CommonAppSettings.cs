using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;


public class CommonAppSettings : MonoBehaviour
{

    public PopUpManager.ScreenType screenType = PopUpManager.ScreenType.LandScape;
    public string backButtonScene;
   // public bool loadSceneOnPhoneBackButton;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
        switch (screenType)
        {
            case PopUpManager.ScreenType.LandScape:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                //PlayerPrefs.SetString(PlayerData.SCREEN_ORIENTATION, "Landscape");
                break;
            case PopUpManager.ScreenType.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                //PlayerPrefs.SetString(PlayerData.SCREEN_ORIENTATION, "Portrait");
                break;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}