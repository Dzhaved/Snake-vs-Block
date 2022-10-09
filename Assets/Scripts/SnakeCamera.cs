using UnityEngine;

public class SnakeCamera : MonoBehaviour
{
    public Snake Snake;
    
    
    void Update()
    {
        transform.position = new Vector3(0, 35, Snake.Segments[0].transform.position.z + 10);
    }
}
