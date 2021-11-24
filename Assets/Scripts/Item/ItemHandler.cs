using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{

    [SerializeField] int healPower = 40;
    [SerializeField] float fireRateMultiplier = 0.9f;
    [SerializeField] float sheildAmount = 5f;
    [SerializeField] float criticleUp = 0.05f;


    public int GetHealPower()
    {
        return healPower;
    }

    public float GetFireRateMultiplier()
    {
        return fireRateMultiplier;
    }

    public float GetSheildAmount()
    {
        return sheildAmount;
    }

    public float GetPowerUpDamage()
    {
        return criticleUp;
    }
}
