using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public class SnakeCamera : MonoBehaviour
{
    public Snake Snake;
    
    
    void Update()
    {
        transform.position = new Vector3(0, 35, Snake.Segments[0].transform.position.z + 10);
    }
}
