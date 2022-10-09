using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Snake Snake; //змея
    public float SnakeForwardSpeed = 10;//скорость змеи
    public float Sensitivity=1;//чувствительность
    public float LevelRightBorder= 9.5f;
    public float LevelLeftBorder = -9.5f;

    private Vector3 _previousMousePosition;  
    private float _sideSpeed; //скорость смещения

    

    void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _sideSpeed += delta.x ;

            if(Mathf.Abs(_sideSpeed) >1f) _sideSpeed =0.1f* Sensitivity * Mathf.Sign(_sideSpeed);
            if (Mathf.Abs(Snake.Segments[0].transform.position.x) < 9.51f) Snake.Segments[0].transform.position += new Vector3(_sideSpeed, 0, SnakeForwardSpeed * 0.01f);            

            _sideSpeed = 0;
        }
        else
        {
            Snake.Segments[0].transform.position += new Vector3(0, 0, SnakeForwardSpeed * 0.01f);
        }
        /*границы уровня*/
        if (Snake.Segments[0].transform.position.x <= LevelLeftBorder) Snake.Segments[0].transform.position = new Vector3(LevelLeftBorder + 0.4f+_sideSpeed, 1, Snake.Segments[0].transform.position.z+ SnakeForwardSpeed * 0.01f);
        else if (Snake.Segments[0].transform.position.x >= LevelRightBorder) Snake.Segments[0].transform.position = new Vector3(LevelRightBorder - 0.4f+ _sideSpeed, 1, Snake.Segments[0].transform.position.z+ SnakeForwardSpeed * 0.01f);
        /***************/
        _previousMousePosition = Input.mousePosition;
    }

   
}