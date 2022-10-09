using TMPro;

using UnityEngine;

public class Segment : MonoBehaviour
{
    public Segment Previous;
    public Segment Next;
    public Snake Snake;
    public int SegmentIndex;
    public TextMeshPro NumberOfSegments;
    public Rigidbody HeadRigidbody;

    public bool isHead=false;
    public bool isTail=false;

    Vector3 LastPosition;

    private void Start()
    {
        LastPosition = Snake.Segments[0].transform.position;
    }



    private void FixedUpdate()
    {
        if (SegmentIndex == 0)
        { 
            if(Snake.Segments.Count == 1)
            {
                Previous = null;
                Next = null;
            }
            else
            {
                Previous = null;
                Next = Snake.Segments[SegmentIndex + 1];
            }
            
        }
        else if (SegmentIndex == Snake.Segments.Count - 1)
        {
            Previous = Snake.Segments[SegmentIndex - 1];
            Next = null;
        }
        else
        {
            Previous = Snake.Segments[SegmentIndex - 1];
            Next = Snake.Segments[SegmentIndex + 1];
        }

        if (Previous==null)
        {
            isHead= true;
        }
        if (Next == null)
        {
            isTail= true;
        }

        if (isHead)
        {
            NumberOfSegments.text = Snake.Segments.Count.ToString();
            return; 
        }
        SegmentMovement();
        LastPosition = Snake.Segments[0].transform.position;
    }


    private void SegmentMovement()
    {        
        float distance = (Snake.Segments[0].transform.position - LastPosition).magnitude; //���������� ����� ������� �������� ������ � ��������� �����������
        if (distance > Snake.BodyDiameter) //���� ���������� ������� ��������� ������, ��� �� ������� ����, ��:
        {
            Vector3 direction = (Snake.Segments[0].transform.position - LastPosition).normalized;//����������� �� ������� �������� ������ �� ��������� �����������
            LastPosition = direction * Snake.BodyDiameter;
            distance -= Snake.BodyDiameter;
        }
        
        transform.position=Vector3.Lerp(transform.position,Previous.transform.position, distance/ Snake.BodyDiameter);
    }   
}
