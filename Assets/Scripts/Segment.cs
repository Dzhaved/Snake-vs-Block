using TMPro;

using UnityEngine;

public class Segment : MonoBehaviour
{
    public Segment Previous;    
    public Snake Snake;
    public int SegmentIndex;
    public TextMeshPro NumberOfSegments;
    public Rigidbody HeadRigidbody;
    public bool IsHead=false;
    public Material HeadMaterial;
    public Material BodyMaterial;
    public ParticleSystem SnakeBlow;

    internal Renderer _snakeBodyRenderer;

    private Vector3 LastPosition;

    private void Awake()
    {
        _snakeBodyRenderer = GetComponent<Renderer>();
        if (!IsHead)
        {
            _snakeBodyRenderer.sharedMaterial = BodyMaterial;
        }
    }

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
            IsHead= true;
        }        

        if (IsHead)
        {
            NumberOfSegments.text = Snake.Segments.Count.ToString();            
            return; 
        }
        if (!IsHead)
        {
            _snakeBodyRenderer.sharedMaterial.SetInt("_SnakeLength", Snake.SnakeLength);
        }
        SegmentMovement();
        LastPosition = Snake.Segments[0].transform.position;
    }


    private void SegmentMovement()
    {        
        float distance = (Snake.Segments[0].transform.position - LastPosition).magnitude; //рассто€ние между текущей позицией головы и последней сохранЄнной
        if (distance > Snake.BodyDiameter) //≈сли предыдущий сегмент сдвинулс€ больше, чем на диаметр тела, то:
        {
            Vector3 direction = (Snake.Segments[0].transform.position - LastPosition).normalized;//направление от текущей позициии головы до последней сохранЄнной
            LastPosition += direction * Snake.BodyDiameter;
            distance -= Snake.BodyDiameter;
        }
        
        transform.position=Vector3.Lerp(transform.position,Previous.transform.position, distance/ Snake.BodyDiameter);
    }   
}
