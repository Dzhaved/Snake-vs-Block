using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
