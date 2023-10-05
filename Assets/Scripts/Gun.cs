using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            var Bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            Bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * BulletSpeed;
        }

    }
}
