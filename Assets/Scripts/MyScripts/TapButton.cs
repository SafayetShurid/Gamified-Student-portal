using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapButton : MonoBehaviour
{
    public Button button;
    public Image buttonImage;
    public TapObjectUI tapObjectUI;
    public TweenScaleUpDown tweenScaleUpDown;

    public virtual void ChangeColor() { }
    public virtual void ResetColor() { }
    public virtual void ChangeSprite() { }
    public virtual void ChangeSprite(Sprite sprite) { }
    public virtual void ResetSprite() { }
    public virtual void ChangeText(string text) { }
    public virtual void ResetText() { }
    public virtual void ChangeColor(Color color) { }
    public virtual void ChangeOutlineColor(Color color) { }
    public virtual void ChangeTextColor(Color color) { }


}
