using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelInfo : MonoBehaviour
{
    public Text CurrentLevelText;
    public Text NextLevelText;
    public Game Game;


    private void Start()
    {       
        CurrentLevelText.text = (Game.LevelIndex).ToString();
        if(Game.LevelIndex <5 )  NextLevelText.text = (Game.LevelIndex + 1).ToString();
        else NextLevelText.text = "F";
    }
}
