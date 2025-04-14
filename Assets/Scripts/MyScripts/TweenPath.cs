using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TweenPath : MonoBehaviour
{
    [SerializeField] Vector3[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        
        DOTween.Init();
        FollowPath();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    void FollowPath()
    {
        transform.DOLocalPath(waypoints, 3f,PathType.Linear,PathMode.Ignore,10,Color.red);
    }
}
