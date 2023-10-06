using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;

    public List<GameObject> enemyColor;
    public GameObject enemy;
    public float enemySpeed;
    public Transform targetPlayer;
    public GameObject enemyPlayer;
    private void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform; 
        enemy = enemyColor[Random.Range(0, enemyColor.Count)];
        enemy.SetActive(true);
    }
    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, 
            targetPlayer.position, step);
        Vector3 targetPos  = targetPlayer.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);   
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targetPlayer.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            targetPlayer.position *= -1.0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag == enemy.tag)
        {
            Destroy(other.gameObject);
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
