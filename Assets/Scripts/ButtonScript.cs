using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Game Game;


    public void ReloadeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
    public void CurrentScoreDefault()
    {
        Game.CurrentScore = 0;
    }
}
