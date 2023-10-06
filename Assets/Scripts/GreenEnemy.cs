using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    public List<GameObject> enemyColor;
    public GameObject enemy;
    public float enemySpeed;
    public Transform targetPlayer;
    private void Awake()
    {
        enemy = enemyColor[Random.Range(0, enemyColor.Count)];
        enemy.SetActive(true);
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red") && CompareTag("Red") || other.CompareTag("Green") && CompareTag("Green") || other.CompareTag("Blue") && CompareTag("Blue"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            return;
        }
        else
        {
            Destroy(other.gameObject);
        }


    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
