using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{    
    public SnakeMovement SnakeMovement;
    public Snake Snake;


    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; set; }


    private void Awake()
    {
        
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;        
        SnakeMovement.enabled = false;
        Snake.SnakeLength = Snake.BaseSnakeLength+1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        SnakeMovement.enabled = false;
        LevelIndex++;
        Invoke("ReloadeLevel", 2);
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }

    }
    private const string LevelIndexKey = "LevelIndex";

    public void ReloadeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
