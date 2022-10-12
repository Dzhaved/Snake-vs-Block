using TMPro;
using UnityEngine;
using Random = System.Random;

public class Blocks : MonoBehaviour
{
    public int BlockHealth;    
    public Collider FoodCollider;   
    public TextMeshPro BlockText;
    

    private Segment _segment;


    private void Awake()
    {                
        Random random = new Random();
        
        if(random.Next(0, 100)<40)    BlockHealth = random.Next(1,5);//лёгкий блок
        else BlockHealth = random.Next(6, 25);//тяжёлый блок
        BlockText.text=BlockHealth.ToString();
       
    }

    private void OnCollisionEnter(Collision collision)
    {              
        if (!collision.collider.TryGetComponent(out Segment s)) return;
        _segment = s;
        Vector3 normal = -collision.GetContact(0).normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.right);        
        if (Mathf.Abs( dot) > 0.01) return;
        if (!s.isHead) return;
        Snake snake = s.Snake;
        snake.Game.CurrentScore++;
        if(snake.Game.BestScore < snake.Game.CurrentScore) snake.Game.BestScore++;
        snake.SnakeLength--;
        snake.RemoveSnakeBody();        
        BlockHealth--;              
    }
   
    private void Update()
    {
        BlockText.text = BlockHealth.ToString();
        if (BlockHealth <= 0)
        {
            Destroy(gameObject);            
        }
    }
    
}
