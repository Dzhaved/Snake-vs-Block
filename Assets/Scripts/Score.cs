using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Game Game;
    public Text BestScoreText;
    public Text CurrentScoreText;

    

    void Update()
    {
        BestScoreText.text = Game.BestScore.ToString();
        if(Game.CurrentState==0)
        CurrentScoreText.text = Game.CurrentScore.ToString();
        else CurrentScoreText.text = null;
    }
}
