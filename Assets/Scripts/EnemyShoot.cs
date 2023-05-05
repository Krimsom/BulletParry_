using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public float bulletSpeed;
    public bool playerDetect;
    public float destroyTime;
    private float nextTimeToFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetect && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetect = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetect = false;
        }
    }

    private void Shoot()
    {
        GameObject instaciatedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bulletRB = instaciatedBullet.GetComponent<Rigidbody2D>();
        Vector2 bulletDirection = new Vector2((PlayerController.sharedInstance.transform.position.x - transform.position.x), (PlayerController.sharedInstance.transform.position.y - transform.position.y));
        bulletDirection.Normalize();
        bulletRB.velocity = bulletDirection * bulletSpeed;
        Destroy(instaciatedBullet, destroyTime);
    }
}
