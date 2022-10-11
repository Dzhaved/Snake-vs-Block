using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Snake Snake;
    public Transform FinishPlatform;
    public Slider Slider;

    private float _acceptableFinishPlayerDistance = 30f;
    private float _startY;
    private float _maximumReachedY;    

    private void Start()
    {
        _startY = Snake.HeadRigidbody.position.z;
        _maximumReachedY = Snake.HeadRigidbody.position.z;
        
    }

    private void Update()
    {
        if(Snake.HeadRigidbody==null)return;        
        _maximumReachedY = Mathf.Max(_maximumReachedY, Snake.HeadRigidbody.position.z);
        Debug.Log(_maximumReachedY.ToString()); 
        float finishZ = FinishPlatform.transform.position.z;        
        float t = Mathf.InverseLerp(_startY, finishZ + _acceptableFinishPlayerDistance, _maximumReachedY);
        Slider.value = t;
        
    }
}
