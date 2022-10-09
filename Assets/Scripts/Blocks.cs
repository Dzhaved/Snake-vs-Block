using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using TMPro.Examples;

using UnityEngine;
using UnityEngine.UI;

using Random = System.Random;

public class Blocks : MonoBehaviour
{
    public int BlockHealth;
    public GameObject Block;
    public TextMeshPro BlockText;

    private void Awake()
    {        
        Random random = new Random();
        BlockHealth = random.Next(1,5);
        BlockText.text=BlockHealth.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Segment s))
        {
            if(!s.isHead)return;
            Snake snake = s.Snake;
            snake.RemoveSnakeBody();
            //Destroy(snake.gameObject);
            BlockHealth--;
            snake.SnakeLength--;

        }
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
