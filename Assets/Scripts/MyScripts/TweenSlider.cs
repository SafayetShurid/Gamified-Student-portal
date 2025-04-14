using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Base;
using System;

public class TweenSlider : Singleton<TweenSlider>
{
    public GameObject container;
    public float xPos = 1250;
    public float duration = 1f;
    public Ease startEase;
    public Ease endEase;

    private Transform _conTrans;
    

    private void Awake()
    {
        if (container != null)
        {
            _conTrans = container.transform;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(transform.localPosition);
            DoTransition(null);
        }    
    }

    public void DoTransition(Action callBack)
    {
        _conTrans.DOLocalMoveX(-xPos, duration).SetEase(startEase).OnComplete(() =>
        {
            _conTrans.localPosition = new Vector3(xPos, _conTrans.localPosition.y, 0);
            callBack?.Invoke();
            _conTrans.DOLocalMoveX(0, duration).SetEase(endEase);

        });
    }
}
