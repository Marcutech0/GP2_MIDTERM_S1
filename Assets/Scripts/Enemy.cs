using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    private void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector3(23.0f, 1.0f, 7.0f);
        // Create and position the cylinder. Reduce the size.
        var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
        // Grab cylinder values and place on the target.
        target = cylinder.transform;
        target.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        // Create and position the floor.
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
    }
    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position,
        target.position, step);
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }

        Vector3 relativePos = target.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}