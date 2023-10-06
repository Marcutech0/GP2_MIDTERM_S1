using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public List<Transform> spawnerList;
    public Transform spawnerLoc;
    public GameObject enemyPrefab;
    public float spawnTime;

    void Awake()
    {
        spawnTime = Random.Range(2, 5);
        spawnerLoc = spawnerList[Random.Range(0, spawnerList.Count)];
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            RandomActiveSpawner();
        }
    }

    private void RandomActiveSpawner()
    {
        spawnTime = Random.Range(2, 5);
        GameObject enemy = Instantiate(enemyPrefab, spawnerLoc.position, spawnerLoc.rotation);
        enemy.GetComponent<Rigidbody>();
        spawnerLoc = spawnerList[Random.Range(0, spawnerList.Count)];
    }
}
