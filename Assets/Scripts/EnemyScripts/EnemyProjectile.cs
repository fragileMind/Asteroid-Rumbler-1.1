using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    Vector2 moveDirection;

    [SerializeField] GameObject player;

    [SerializeField] GameObject hitEffect;
    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player")==true)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = -transform.up * moveSpeed;
            Invoke("DestroyProjectile", 5f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            DestroyProjectile();
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