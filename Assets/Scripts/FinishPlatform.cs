using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
     
    private void OnTriggerEnter(Collider other)
    {
             
        if (other.TryGetComponent(out Segment s))
        {            
            if (s.Snake.Game.CurrentState== 0)
            {  
                s.Snake.ReachFinish();               
            }
        }
    }
    
}
