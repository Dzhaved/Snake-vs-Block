using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlatform : MonoBehaviour
{
    static int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        count++;        
        if (other.TryGetComponent(out Segment s))
        {            
            if (count == 1)
            {
                Debug.Log(count.ToString());
                Debug.Log("i'm on finnish");
                s.Snake.ReachFinish();
                Invoke("ReloadLevel", 3);
            }
        }
    }
    public void ReloadeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
