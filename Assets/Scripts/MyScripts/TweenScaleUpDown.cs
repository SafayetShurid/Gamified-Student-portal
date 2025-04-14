using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenScaleUpDown : MonoBehaviour
{
    private RectTransform _rectTransform;
    [SerializeField] private float _scaleValue;
    [SerializeField] private float _scaleDuration;

    private Vector3 _initialScale;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _initialScale = GetComponent<RectTransform>().localScale;

    }


    public void ScaleUpDown()
    {
        _rectTransform.DOScale(_scaleValue, _scaleDuration).OnComplete(() =>
        {
            _rectTransform.DOScale(_initialScale, _scaleDuration);
        });
    }
}
