using System.Collections.Generic;

using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SnakeHead;
    public GameObject SnakeBody;
    public Snake SnakeComponent;
    public float BodyDiameter = 1;
    [Min(0)]
    public int SnakeLength;
    public List<Segment> Segments = new List<Segment>();

    public SnakeMovement SnakeMovement;
    public Rigidbody HeadRigidbody;


    private void Awake()
    {
        for (int i = 0; i < SnakeLength; i++) AddSnakeBody();
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {

            AddSnakeBody();
            SnakeLength++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SnakeLength--;
            RemoveSnakeBody();
        }
    }


    public void AddSnakeBody()
    {
        if (Segments.Count == 0)
        {
            GameObject body = Instantiate(SnakeHead, transform.position, Quaternion.identity, transform);
            HeadRigidbody = body.AddComponent<Rigidbody>();
            HeadRigidbody.mass = .001f;
            HeadRigidbody.angularDrag = 0;
            HeadRigidbody.freezeRotation = true;
            HeadRigidbody.useGravity=false;
            if (body.TryGetComponent(out Segment s))
            {
                s.Snake = SnakeComponent;
                s.SegmentIndex = Segments.Count;
                Segments.Add(s);
            }
            Segments[0].HeadRigidbody = HeadRigidbody;

        }
        else
        {
            GameObject body = Instantiate(SnakeHead, Segments[Segments.Count - 1].transform.position, Quaternion.identity, transform);
            if (body.TryGetComponent(out Segment s))
            {
                s.Snake = SnakeComponent;
                s.SegmentIndex = Segments.Count;
                Segments.Add(s);
            }

        }
    }

    public void RemoveSnakeBody()
    {

        Destroy(Segments[0].gameObject);
        Segments.RemoveAt(0);
        HeadRigidbody = Segments[0].gameObject.AddComponent<Rigidbody>();
        HeadRigidbody.mass = .001f;
        HeadRigidbody.angularDrag = 0;
        HeadRigidbody.freezeRotation = true;        
        HeadRigidbody.useGravity = false;
        Segments[0].HeadRigidbody = HeadRigidbody;
        foreach (Segment s in Segments)
        {
            s.SegmentIndex--;
        }


    }

}
