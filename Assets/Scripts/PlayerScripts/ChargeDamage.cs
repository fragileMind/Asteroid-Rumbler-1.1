using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDamage : MonoBehaviour
{
    UnitCollisionPlayer utcp;
    int chargedamage;

    private void Start()
    {
        utcp = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitCollisionPlayer>(); 
        chargedamage = utcp.GetChargePower();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == ("Enemy"))
        {
            hitInfo.GetComponent<UnitCollisionEnemy>().hitProcess(chargedamage);
        }
    }

}