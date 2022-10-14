using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{    
    public SnakeMovement SnakeMovement;
    public Snake Snake;
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public GameObject Info;
    public Text LevelInfoText;
    public Text StatusText;
    public Slider Slider;
    public GameObject[] BestScoreUI;
    public Text BestScoreText;
    public ParticleSystem WinEffect;

    private GameObject _screen;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; set; }
       


    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;        
        SnakeMovement.enabled = false;
        Snake.SnakeLength = Snake.BaseSnakeLength;       
        _screen =LoseScreen;
        Invoke("ScreenActivate", 1f);
        Invoke("LoseScreenText", 1f);
        CurrentScore = 0;

    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        SnakeMovement.enabled = false;
        LevelIndex++;           
        _screen=WinScreen;        
        Invoke("ScreenActivate", 1f);
        Invoke("WinScreenText", 1f);
        
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

    private void ScreenActivate()
    {
        _screen.SetActive(true);
        
    }
    private void LoseScreenText()
    {
        OnScreenInfo();
        StatusText.color = Color.black;
        StatusText.text = "You Lose";
        LevelInfoText.color = Color.yellow;
        LevelInfoText.text = ((int)(Slider.value * 100)).ToString() + "% completed";
    }
    private void WinScreenText()
    {
        WinEffect.Play();
        OnScreenInfo();        
        StatusText.color = Color.white;
        StatusText.text = "You Win";
        LevelInfoText.color = Color.yellow;
        LevelInfoText.text = "Level " + (LevelIndex - 1).ToString() + " passed";
        if(LevelIndex>5)LevelIndex = 1;
        
    }

    private void OnScreenInfo()
    {
        Info.SetActive(true);
        BestScoreUI[0].SetActive(false);
        BestScoreText.text = BestScore.ToString();
        BestScoreUI[1].SetActive(true);
    }

    private const string BestScoreKey = "BestScore";
    public int BestScore
    {
        get => PlayerPrefs.GetInt(BestScoreKey, 0);
        set
        {
            PlayerPrefs.SetInt(BestScoreKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string CurrentScoreKey = "CurrentScore";
    public int CurrentScore
    {
        get => PlayerPrefs.GetInt(CurrentScoreKey, 0);
        set
        {
            PlayerPrefs.SetInt(CurrentScoreKey, value);
            PlayerPrefs.Save();
        }
    }
  
}
