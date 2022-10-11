using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Game Game;
    public Text BestScoreText;
    public Text CurrentScoreText;

    

    void Update()
    {
        BestScoreText.text = "Best: " + Game.BestScore.ToString();
        CurrentScoreText.text = Game.CurrentScore.ToString();
    }
}
