using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenShake : MonoBehaviour
{
    private RectTransform _rectTransform;
    public float duration, strength, randomness;
    public int vibrate;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }    

    public void DOShake()
    {
        _rectTransform.DOShakeAnchorPos(duration, strength, vibrate, randomness);
    }
}
