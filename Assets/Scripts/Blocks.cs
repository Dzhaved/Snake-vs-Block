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
        BlockHealth = random.Next(1,5);
        BlockText.text=BlockHealth.ToString();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == FoodCollider) gameObject.SetActive(false);        
        if (!collision.collider.TryGetComponent(out Segment s)) return;
        _segment = s;
        Vector3 normal = -collision.GetContact(0).normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.right);        
        if (Mathf.Abs( dot) > 0.01) return;
        if (!s.isHead) return;
        Snake snake = s.Snake;
        snake.RemoveSnakeBody();        
        BlockHealth--;
        snake.SnakeLength--;
    }
   
    private void Update()
    {
        BlockText.text = BlockHealth.ToString();
        if (BlockHealth <= 0)
        {
           gameObject.SetActive(false);
        }
    }
    
}
