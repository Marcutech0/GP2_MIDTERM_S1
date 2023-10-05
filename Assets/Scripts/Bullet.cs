using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public Material objectMaterial;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a Renderer component.
        Renderer otherRenderer = collision.gameObject.GetComponent<Renderer>();
        if (otherRenderer != null)
        {
            // Check if the collided object has the same material as this object.
            if (otherRenderer.material == objectMaterial)
            {
                // Destroy the collided object.
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("Collided with a different material");
            }
        }
    }
}