using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour {


    [SerializeField] float speed;
    [SerializeField] float lineOfSight;
    [SerializeField] float shootingRange;
    [SerializeField] float fireRate = 1f;
    private float nextFireTime;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletParent;
    [SerializeField] Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer>shootingRange)
        {
            RotateTowards(player.position);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        void RotateTowards(Vector2 player)
        {
            var offset = 90f;
            Vector2 direction = player - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
