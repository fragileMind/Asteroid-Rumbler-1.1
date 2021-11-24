using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgDealerPlayer_Critic : MonoBehaviour
{
    UnitCollisionPlayer utcp;
    int playerdamage;

    private void Start()
    {
        utcp = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitCollisionPlayer>();
        playerdamage = utcp.GetFirePower();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == ("Enemy"))
        {
            hitInfo.GetComponent<UnitCollisionEnemy>().hitProcess(playerdamage*3);
            Destroy(gameObject);
        }
    }
}
