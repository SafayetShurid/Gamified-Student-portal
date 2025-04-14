using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapObjectUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isCorrect;

    private Vector3 _localScale;

    public bool isScaleDown;
    public float scaleDownfactor;

    public bool isScaleUp;
    public float scaleUpfactor;

    public bool isTapDown;

    public delegate void OnMouseDownCall();
    public delegate void OnMouseUpCall();
    public event OnMouseDownCall onMouseDown;
    public event OnMouseUpCall onMouseUp;

    void Awake()
    {

        _localScale = transform.localScale;

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        transform.localScale = _localScale;
        onMouseUp?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log(_localScale);
        if (isTapDown)
        {
            if (isScaleUp)
            {
                transform.localScale = new Vector2(_localScale.x * scaleUpfactor, _localScale.y * scaleUpfactor);
            }
            else if (isScaleDown)
            {
                transform.localScale = new Vector2(_localScale.x / scaleDownfactor, _localScale.y / scaleDownfactor);
            }

        }

        onMouseDown?.Invoke();
    }

    public void SetLocalScale(Vector3 scale)
    {
        _localScale = scale;
    }
}
