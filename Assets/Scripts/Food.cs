using TMPro;

using UnityEngine;

using Random = System.Random;

public class Food : MonoBehaviour
{
    public GameObject food;
    public int FoodValue;
    public TextMeshPro FoodText;

    

    private void Awake()
    {              
        Random random = new Random();
        FoodValue = random.Next(2, 5);
        FoodText.text = FoodValue.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent(out Segment s))
        {
            Snake snake=s.Snake;  
            for (int i = 0; i < FoodValue; i++) 
            { 
                snake.AddSnakeBody();
                snake.SnakeLength++;
            }
            gameObject.SetActive(false);
        }
    }

}
