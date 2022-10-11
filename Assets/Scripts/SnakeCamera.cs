using UnityEngine;

public class SnakeCamera : MonoBehaviour
{
    public Snake Snake;
    
    
    void Update()
    {
        if (Snake.Segments[0] == null) return;
        Vector3 targetPosition = new Vector3(0, 35, Snake.Segments[0].transform.position.z + 10);

        transform.position = Vector3.MoveTowards(transform.position,targetPosition,Snake.SnakeMovement.SnakeForwardSpeed) ;        
    }
}
