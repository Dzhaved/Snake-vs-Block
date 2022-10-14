using UnityEngine;

public class SnakeCamera : MonoBehaviour
{   
    public Game Game;


    void Update()
    {
        if (Game.CurrentState == Game.State.Playing) 
        { 
        Vector3 targetPosition = new Vector3(0, 35, Game.Snake.Segments[0].transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Game.SnakeMovement.SnakeForwardSpeed); 
        }
        
    }
}
