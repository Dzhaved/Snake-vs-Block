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
    public GameObject Text;

    private TextMeshPro _blockText;

    private void Awake()
    {
        Text.TryGetComponent(out TextMeshPro text);
        _blockText = text;
        Random random = new Random();
        BlockHealth = random.Next(1,5);
        text.text=BlockHealth.ToString();

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
        _blockText.text = BlockHealth.ToString();
        if (BlockHealth <= 0)
        {
           gameObject.SetActive(false);
        }
    }
}
