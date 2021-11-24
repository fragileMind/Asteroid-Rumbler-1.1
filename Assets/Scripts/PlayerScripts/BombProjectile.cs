using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] float speed = 20f;
    [SerializeField] GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.up * speed;


        Invoke("DestroyProjectile", 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            
        }

        if (other.CompareTag("Environment"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            DestroyProjectile();
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
