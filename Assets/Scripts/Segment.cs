using TMPro;

using UnityEngine;

public class Segment : MonoBehaviour
{
    public Segment Previous;
    //public Segment Next;
    public Snake Snake;
    public int SegmentIndex;
    public TextMeshPro NumberOfSegments;
    public Rigidbody HeadRigidbody;

    public bool isHead=false;    

    private Vector3 LastPosition;

    private void Start()
    {
        LastPosition = Snake.Segments[0].transform.position;
    }



    private void Update()
    {        
        if (SegmentIndex == 0)
        {            
                Previous = null;    
        }
        else if (SegmentIndex == Snake.Segments.Count - 1)
        {
            Previous = Snake.Segments[SegmentIndex - 1];           
        }
        else
        {
            Previous = Snake.Segments[SegmentIndex - 1];           
        }

        if (Previous==null)
        {
            isHead= true;
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
        float distance = (Snake.Segments[0].transform.position - LastPosition).magnitude; //���������� ����� ������� �������� ������ � ��������� ����������
        if (distance > Snake.BodyDiameter) //���� ���������� ������� ��������� ������, ��� �� ������� ����, ��:
        {
            Vector3 direction = (Snake.Segments[0].transform.position - LastPosition).normalized;//����������� �� ������� �������� ������ �� ��������� ����������
            LastPosition += direction * Snake.BodyDiameter;
            distance -= Snake.BodyDiameter;
        }
        
        transform.position=Vector3.Lerp(transform.position,Previous.transform.position, distance/ Snake.BodyDiameter);
    }   
}
