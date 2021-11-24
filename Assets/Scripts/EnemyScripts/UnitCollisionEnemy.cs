using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollisionEnemy : MonoBehaviour
{
    [Header("Enemy Configuration")]
    [SerializeField] int health = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] GameObject deathEffect;
    [Header("Item Drop Configuration")]
    [SerializeField] float dropRate = 0.4f;
    [SerializeField] List<GameObject> pickUpList;

 

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        CreateDropList();

    }

    private void CreateDropList()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hitProcess(int playerdamage)
    {
        Debug.Log(playerdamage);
        health -= playerdamage;
        if (health <= 0)
        {
            GameObject deatheffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deatheffect, 3f);
            DropItem();
            Die();
        }
    }

    private void DropItem()
    {
        float dropNumber = Random.Range(0.0f, 1.0f);
        Debug.Log(dropNumber);
        if (dropNumber <= dropRate)
        {        
            int listNumber = Random.Range(0, pickUpList.Count);
            Instantiate(pickUpList[listNumber], gameObject.transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        FindObjectOfType<PlayerUI>().AddToEnemyCounter();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }

    public int GetHealth()
    {
        return health;
    }
}