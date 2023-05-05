using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public int destroyTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject instaciatedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bulletRB = instaciatedBullet.GetComponent<Rigidbody2D>();
        if (PlayerController.sharedInstance.isLeft)
        {
            bulletRB.velocity = new Vector2(-bulletSpeed, 0);
        }

        else
        {
            bulletRB.velocity = new Vector2(bulletSpeed, 0);
        }

        Destroy(instaciatedBullet, destroyTime);
    }
}
