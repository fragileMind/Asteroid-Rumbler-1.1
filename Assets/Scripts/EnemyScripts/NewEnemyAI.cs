using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NewEnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWayPointDistance = 3f;
    [SerializeField] float stoppingDistanceMax;
    [SerializeField] float stoppingDistanceMin;
    [SerializeField] float retreatDistanceMax;
    [SerializeField] float retreatDistanceMin;

    [SerializeField] float timeBtwShots;
    [SerializeField] float startTimeBtwShots;
    [SerializeField] float laserDuration;

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject firepoint;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D myRb2d;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        myRb2d = GetComponent<Rigidbody2D>();


        if (GameObject.FindGameObjectWithTag("Player") == true)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

            timeBtwShots = startTimeBtwShots;
        }

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
    }
    void UpdatePath()
    {
        if(seeker.IsDone())
        {
           seeker.StartPath(myRb2d.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;
        if(currentWaypoint>= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else
        {
            reachedEndOfPath = false;
        }

        if (GameObject.FindGameObjectWithTag("Player") == true)
        {
            if (Vector2.Distance(myRb2d.position, target.position) > Random.Range(stoppingDistanceMin, stoppingDistanceMax))
            {
                RotateTowards(target.position);
                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - myRb2d.position).normalized;
                Vector2 force = direction * speed * Time.deltaTime;
                myRb2d.AddForce(force);

                float distance = Vector2.Distance(myRb2d.position, path.vectorPath[currentWaypoint]);
                if(distance<nextWayPointDistance)
                {
                    currentWaypoint++;
                }
            }
            else if (Vector2.Distance(myRb2d.position, target.position) < Random.Range(stoppingDistanceMin, stoppingDistanceMax) && Vector2.Distance(myRb2d.position, target.position) > Random.Range(retreatDistanceMin, retreatDistanceMax))
            {
                RotateTowards(target.position);
                myRb2d.velocity=Vector2.zero;

            }
            else if (Vector2.Distance(myRb2d.position, target.position) < Random.Range(retreatDistanceMin, retreatDistanceMax))
            {
                RotateTowards(target.position);
                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - myRb2d.position).normalized;
                Vector2 force = direction * -speed * Time.deltaTime;
                myRb2d.AddForce(force);
            }
            Fire();
        }
    }
        void Fire()
        {
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

        void RotateTowards(Vector2 player)
        {
            var offset = 90f;
            Vector2 direction = player - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }
}
