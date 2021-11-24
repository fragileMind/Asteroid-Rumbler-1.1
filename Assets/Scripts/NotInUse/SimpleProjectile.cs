using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour { 

    public float speed;
    
    private Transform player;
    private Vector2 target;
    private float _time;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }


        {
            _time += Time.deltaTime;
            if (_time > 10)
            {
                DestroyProjectile();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
