using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Segment s))
        {

            if (s.transform.position.x < transform.position.x - 0.3f) s.Snake.SnakeMovement.LevelRightBorder = transform.position.x;

            if (s.transform.position.x > transform.position.x + 0.3f) s.Snake.SnakeMovement.LevelLeftBorder = transform.position.x;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Segment s))
        {
            s.Snake.SnakeMovement.LevelRightBorder = 9.5f;
            s.Snake.SnakeMovement.LevelLeftBorder = -9.5f;
        }
    }
}
