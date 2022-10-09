using Unity.VisualScripting;

using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Snake Snake; //змея
    public float SnakeForwardSpeed = 10;//скорость змеи
    public float Sensitivity=1;//чувствительность
    public float LevelLeftBorder = 9.5f;
    public float LevelRightBorder = -9.5f;

    private Vector3 _previousMousePosition;  
    private float _sideSpeed; //скорость смещения

    

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _sideSpeed += delta.x ;

            //if(Mathf.Abs(_sideSpeed) >1f) _sideSpeed =Sensitivity * Mathf.Sign(_sideSpeed);
            //if (Mathf.Abs(Snake.Segments[0].transform.position.x) < 9.51f) Snake.Segments[0].HeadRigidbody.velocity = new Vector3(_sideSpeed, 0, SnakeForwardSpeed );
            //if (Mathf.Abs(Snake.Segments[0].transform.position.x) < 9.51f) Snake.Segments[0].transform.position += new Vector3(_sideSpeed, 0, SnakeForwardSpeed * 0.01f);            

        }
        else
        {
            _sideSpeed = 0;
        }
        
        _previousMousePosition = Input.mousePosition;
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(_sideSpeed) > 1f) _sideSpeed = Sensitivity * Mathf.Sign(_sideSpeed);
        if (Mathf.Abs(Snake.Segments[0].transform.position.x) < 9.51f) Snake.Segments[0].HeadRigidbody.velocity = new Vector3(_sideSpeed, 0, SnakeForwardSpeed);

        _sideSpeed = 0;
        /*границы уровня*/
        if (Snake.Segments[0].transform.position.x <= LevelLeftBorder) Snake.Segments[0].transform.position = new Vector3(LevelLeftBorder+0.25f, 1, Snake.Segments[0].transform.position.z);
        else if (Snake.Segments[0].transform.position.x >= LevelRightBorder) Snake.Segments[0].transform.position = new Vector3(LevelRightBorder-0.25f, 1, Snake.Segments[0].transform.position.z);
        /***************/
    }


}