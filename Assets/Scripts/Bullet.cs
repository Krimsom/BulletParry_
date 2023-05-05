using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //velocidad de la bala 
    public float speed = 25f;
    
    void Start()
    {
        //la bala se mueve hacia la izquierda (prueba)
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthController.sharedInstance.DealWithDamage();
        Destroy(gameObject);
    }
}
