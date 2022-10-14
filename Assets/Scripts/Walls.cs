using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Blocks b)) Destroy(gameObject); 
        if (collision.collider.TryGetComponent(out Food f)) Destroy(gameObject);
    }
}
