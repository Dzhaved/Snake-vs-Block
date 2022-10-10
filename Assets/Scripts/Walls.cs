using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Blocks b)) Destroy(gameObject); //gameObject.SetActive(false);
        if (collision.collider.TryGetComponent(out Food f)) Destroy(gameObject);//gameObject.SetActive(false);
    }
}
