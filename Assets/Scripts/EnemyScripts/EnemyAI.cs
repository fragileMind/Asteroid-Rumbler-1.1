using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    [SerializeField] float retreatDistance;

    [SerializeField] float timeBtwShots;
    [SerializeField] float startTimeBtwShots;

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject firepoint;
    [SerializeField] Transform player;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == true)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            timeBtwShots = startTimeBtwShots;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == true)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                RotateTowards(player.position);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                RotateTowards(player.position);
                transform.position = this.transform.position;

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                RotateTowards(player.position);
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            void RotateTowards(Vector2 player)
            {
                var offset = 90f;
                Vector2 direction = player - (Vector2)transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            }



            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, firepoint.transform.position, firepoint.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }
    }
}
