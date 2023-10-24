using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public float fireRate;
    private float baseFireRate;

    // Start is called before the first frame update
    void Start()
    {
        baseFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;

        if(fireRate <=0) 
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        Rigidbody BulletRB = Bullet.GetComponent<Rigidbody>();
        BulletRB.AddForce(BulletSpawnPoint.forward * BulletSpeed, ForceMode.Impulse);
        fireRate = baseFireRate;
    }
}
