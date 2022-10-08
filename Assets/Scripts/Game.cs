using UnityEngine;

public class Game : MonoBehaviour
{    
    private SnakeMovement _snakeMovement;
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
        _snakeMovement.enabled = false;
        
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        _snakeMovement.enabled = false;
        LevelIndex++;
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
}
