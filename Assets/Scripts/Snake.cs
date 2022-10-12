using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SnakeHead;   
    public Snake SnakeComponent;
    public float BodyDiameter = 1;
    public int BaseSnakeLength;
    [Min(0)]    
    public List<Segment> Segments = new List<Segment>();
    public SnakeMovement SnakeMovement;
    public Rigidbody HeadRigidbody;
    public Game Game;    

    public int SnakeLength
    {
        get => PlayerPrefs.GetInt(SnakeLengthKey, BaseSnakeLength);
         set
        {
            PlayerPrefs.SetInt(SnakeLengthKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string SnakeLengthKey = "SnakeLength";

    private void Awake()
    {
        for (int i = 0; i < SnakeLength; i++) AddSnakeBody();
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        HeadRigidbody.velocity = new Vector3(0,0,SnakeMovement.SnakeForwardSpeed);
        Invoke("SnakeStrop", 2);
    }
    public void Die()
    {        
        Game.OnPlayerDied();
        HeadRigidbody.velocity = Vector3.zero;
    }

    public void AddSnakeBody()
    {
        GameObject body;
        if (Segments.Count == 0)
        {
            body = Instantiate(SnakeHead, transform.position, Quaternion.identity, transform);
            body.AddComponent<SphereCollider>();
            HeadRigidbody = body.AddComponent<Rigidbody>();
            HeadRigidbody.mass = 1f;
            HeadRigidbody.angularDrag = 0;
            HeadRigidbody.freezeRotation = true;
            Segment s= body.GetComponent<Segment>();
            s.Snake = SnakeComponent;
            s.SegmentIndex = Segments.Count;
            s.HeadRigidbody = HeadRigidbody;
            Segments.Add(s);
            

        }
        else
        {
             body = Instantiate(SnakeHead, Segments[Segments.Count - 1].transform.position, Quaternion.identity, transform);
            Segment s = body.GetComponent<Segment>();
            s.Snake = SnakeComponent;
            s.SegmentIndex = Segments.Count;
            Segments.Add(s);            

        }        
    }

    public void RemoveSnakeBody()
    {
        if (Segments.Count <=1) Die();
        foreach(Segment s in Segments)
            if (s.isHead) Destroy(s.gameObject);
        
        if (Segments.Count > 1)
        {
            Segments.RemoveAt(0);
            Segments[0].gameObject.AddComponent<SphereCollider>();
            HeadRigidbody = Segments[0].gameObject.AddComponent<Rigidbody>();
            HeadRigidbody.angularDrag = 0;
            HeadRigidbody.freezeRotation = true;
            Segments[0].HeadRigidbody = HeadRigidbody;

            foreach (Segment s in Segments)
            {
                s.SegmentIndex--;
            }
        }
        
    }

    private void SnakeStrop()
    {
        HeadRigidbody.velocity = Vector3.zero;
    }

}
