using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using Random = System.Random;

public class Blocks : MonoBehaviour
{
    public int BlockHealth;
    public TextMeshPro BlockText;
    public Material[] BlockMaterial;    
    

    private Renderer _blockRenderer;

       


    private void Start()
    {
        Random random = new Random();
        BlockHealth = random.Next(1, 26);      
        BlockText.text = BlockHealth.ToString();
        int i = (BlockHealth-1)/2;
        UpdateMaterial(BlockMaterial[i]);       
    }



    private void UpdateMaterial(Material BlockMaterial)
    {
        _blockRenderer=gameObject.GetComponent<Renderer>();
        _blockRenderer.sharedMaterial = BlockMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Segment s)) 
        {            
            return; 
        }        
        Vector3 normal = -collision.GetContact(0).normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.right);        
        if (Mathf.Abs( dot) > 0.01) return;
        if (!s.IsHead) return;
        Snake snake = s.Snake;
        snake.Game.CurrentScore++;
        if(snake.Game.BestScore < snake.Game.CurrentScore) snake.Game.BestScore++;
        snake.SnakeLength--;        
        snake.RemoveSnakeBody();        
        BlockHealth--;              
    }

    private void Update()
    {
        
        _blockRenderer.sharedMaterial.SetFloat("_CurrentBlockHealth", BlockHealth);
        BlockText.text = BlockHealth.ToString();
        if (BlockHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
