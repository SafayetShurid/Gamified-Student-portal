using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class TweenEffect : MonoBehaviour
{
    public Ease ease = Ease.Linear;
    public Ease easeBack = Ease.InOutBack;
    public float duration = 0.5f;
    public float delay = 0;
    public float pos = 1200f;

    private RectTransform rect;

    public RectTransform targetDestination;

    private Vector3 _initialPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        _initialPos = rect.localPosition;
    }

    private void OnEnable()
    {
        rect = GetComponent<RectTransform>();
    }

    public void MoveToUp(Action callback = null)
    {
        rect.DOAnchorPosY(pos, duration).SetDelay(delay).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void MoveToDown(Action callback = null)
    {
        rect.DOAnchorPosY(-pos, duration).SetDelay(delay).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void MoveToLeft(Action callback = null)
    {
        //  Debug.Log("Getting Called");
        rect.DOAnchorPosX(-pos, duration).SetDelay(delay).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
                // Debug.Log("Getting Called");
            });
    }

    public void MoveToRight(Action callback = null)
    {
        rect.DOAnchorPosX(pos, duration).SetDelay(delay).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void MoveToOrigin(Action callback = null)
    {
        rect.DOLocalMove(Vector2.zero, 2f).SetDelay(delay).SetEase(Ease.OutBack).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void MoveToDestination()
    {
        rect.DOLocalMove(targetDestination.localPosition, duration);
    }

    public void MoveToDestinationWithEase(Action callback = null)
    {
        rect.DOLocalMove(targetDestination.localPosition, duration).SetEase(ease).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void MoveToInitial(Action callback = null)
    {
        rect.DOLocalMove(_initialPos, duration).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void SetInitialPosition(Vector2 pos)
    {
        _initialPos = pos;
    }

    public void SetTargetDestination(RectTransform rectTransform)
    {
        targetDestination = rectTransform;
    }

    #region WithoutCallBack
    public void MoveToUp()
    {
        rect.DOAnchorPosY(pos, duration).SetDelay(delay).SetEase(ease);
    }

    public void MoveToDown()
    {
        rect.DOAnchorPosY(-pos, duration).SetDelay(delay).SetEase(ease);

    }

    public void MoveToLeft()
    {

        rect.DOAnchorPosX(-pos, duration).SetDelay(delay).SetEase(ease);

    }

    public void MoveToRight()
    {
        rect.DOAnchorPosX(pos, duration).SetDelay(delay).SetEase(ease);
    }

    public void MoveToOrigin()
    {
        rect.DOLocalMove(Vector2.zero, 0.8f).SetDelay(delay).SetEase(easeBack);
    }

    public void MoveToInitial()
    {
        rect.DOLocalMove(_initialPos, duration);        
    }

    #endregion
}



