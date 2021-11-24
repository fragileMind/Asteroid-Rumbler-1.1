using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [SerializeField] int enemydamage = 20;
    [SerializeField] GameObject hitEffect;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            GameObject effect = Instantiate(hitEffect, collisionPoint, Quaternion.identity);
            collision.gameObject.GetComponent<UnitCollisionPlayer>().hitProcess(enemydamage);
            Destroy(effect, 3f);
        }
    }

}
