using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Snake Snake; //змея
    public float SnakeForwardSpeed = 10;//скорость змеи
    public float Sensitivity=1;//чувствительность


    private Vector3 _previousMousePosition;  
    private float _sideSpeed; //скорость смещения

    

    void FixedUpdate()
    {
        Snake.Segments[0].transform.position += new Vector3(0, 0, SnakeForwardSpeed * 0.01f);
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _sideSpeed += delta.x ;

            if(Mathf.Abs(_sideSpeed) >1f) _sideSpeed =0.1f* Sensitivity * Mathf.Sign(_sideSpeed);
            if (Mathf.Abs(Snake.Segments[0].transform.position.x) < 9.51f) Snake.Segments[0].transform.position += new Vector3(_sideSpeed, 0,0);            

            _sideSpeed = 0;
        }
        /*границы уровня*/
        if (Snake.Segments[0].transform.position.x <= -9.51f) Snake.Segments[0].transform.position = new Vector3(-9.49f, 1, Snake.Segments[0].transform.position.z);
        else if (Snake.Segments[0].transform.position.x >= 9.51f) Snake.Segments[0].transform.position = new Vector3(9.5f, 1, Snake.Segments[0].transform.position.z);
        /***************/
        _previousMousePosition = Input.mousePosition;
    }

   
}