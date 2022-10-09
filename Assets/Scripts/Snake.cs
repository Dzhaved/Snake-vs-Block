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
    public List<Segment> Segments=new List<Segment>();


    private Rigidbody _headRigibody;
    

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
            _headRigibody = body.AddComponent<Rigidbody>();
            _headRigibody.mass=.001f;
            _headRigibody.angularDrag = 0;
            _headRigibody.freezeRotation=true;
            _headRigibody.useGravity=false;
            if(body.TryGetComponent(out Segment s))
            {
                s.Snake = SnakeComponent;   
                s.SegmentIndex=Segments.Count;                
                Segments.Add(s);
            }                    
            
        }
        else
        {
            GameObject body = Instantiate(SnakeHead, Segments[Segments.Count-1].transform.position, Quaternion.identity, transform); 
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
         _headRigibody = Segments[0].gameObject.AddComponent<Rigidbody>();        
        _headRigibody.mass = .001f;
        _headRigibody.angularDrag = 0;
        _headRigibody.freezeRotation = true;
        _headRigibody.useGravity = false;
        foreach (Segment s in Segments)
        {
            s.SegmentIndex--;
        }        
        

    }

}
