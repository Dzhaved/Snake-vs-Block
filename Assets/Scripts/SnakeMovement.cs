using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Snake Snake;
    public Camera Camera;
    public float SnakeForwardSpeed = 10;
    public float Sensitivity=1; 

    private Vector3 _previousMousePosition;  
    private float _sideSpeed;

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousMousePosition=Camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _sideSpeed = 0;
        }
        else  if (Input.GetMouseButton(0))
        {
            Vector3 delta = Camera.ScreenToViewportPoint(Input.mousePosition) - _previousMousePosition;
            _sideSpeed += delta.x*Sensitivity ;
            _previousMousePosition = Camera.ScreenToViewportPoint(Input.mousePosition);
        }        
        
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(_sideSpeed) >  4) _sideSpeed = 4 * Mathf.Sign(_sideSpeed);
        if (Snake.Segments[0]!=null) Snake.Segments[0].HeadRigidbody.velocity = new Vector3(_sideSpeed*10, 0, SnakeForwardSpeed);

        _sideSpeed = 0;       
    }


}