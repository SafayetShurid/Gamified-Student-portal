using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class PopUpManager : Singleton<PopUpManager>
{
    public enum ScreenType
    {
        LandScape,Portrait
    }

    [SerializeField] private GameObject _errorWindowPortrait;
    [SerializeField] private GameObject _errorWindowLandscape;
    [SerializeField] private GameObject _noConnectionLandscape;
    [SerializeField] private GameObject _sensitiveContentLandscape;
    [SerializeField] private GameObject _specificContentLandscape;
    [SerializeField] private GameObject _confirmQuitLandscape;
    [SerializeField] private GameObject _5MinuteLeftLandscape;
    [SerializeField] private GameObject _DailyLimitLandscape;
    [SerializeField] private GameObject _SoundPermissionLandscape;
    [SerializeField] private GameObject _PaymentSuccessPortrait;
    [SerializeField] private GameObject _PaymentFailedPortrait;

    public GameObject[] Screens;
    public int counter = 0;

    public void ShowErroWindow(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.LandScape:
                _errorWindowLandscape.SetActive(true);
                break;
            case ScreenType.Portrait:
                _errorWindowPortrait.SetActive(true);
                break;
        }
    }

    public void ShowContentLockedWindow(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.LandScape:
                _specificContentLandscape.SetActive(true);
                break;
            case ScreenType.Portrait:
                _specificContentLandscape.SetActive(true);
                break;
        }
    }

    public void ShowPaymentSuccessWindow(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.LandScape:
                _PaymentSuccessPortrait.SetActive(true);
                break;
            case ScreenType.Portrait:
                _PaymentSuccessPortrait.SetActive(true);
                break;
        }
    }

    public void ShowPaymentFailedWindow(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.LandScape:
                _PaymentFailedPortrait.SetActive(true);
                break;
            case ScreenType.Portrait:
                _PaymentFailedPortrait.SetActive(true);
                break;
        }
    }

    public void Next()
    {
        if(counter!=Screens.Length - 1)
        {
            Screens[counter].SetActive(false);
            counter++;
            Screens[counter].SetActive(true);
        }
       
    }

    public void Previous()
    {
        if (counter != 0)
        {
            Screens[counter].SetActive(false);
            counter--;
            Screens[counter].SetActive(true);
        }
    }
}