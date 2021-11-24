using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UnitCollisionPlayer : MonoBehaviour
{
    PlayerController playerController;
    float fireRateRank;
    // Start is called before the first frame update
    [SerializeField] float health = 100f;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float maxSheild = 0f;
    [SerializeField] float sheild;
    [SerializeField] float sheildRegenRate = 3f;
    [SerializeField] float nextSheildRegenTimer = 0f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] GameObject deathEffect;

    [SerializeField] int firePower;
    [SerializeField] int chargePower;
    [SerializeField] float criticleRate=0f;
    [SerializeField] CameraController cameraController;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI sheildText;
    [SerializeField] TextMeshProUGUI criticText;
    // Start is called before the first frame update
    void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        fireRateRank = playerController.GetFireRate();
        health = maxHealth;
        if(PlayerPrefs.HasKey("MaxSheild"))
        {
            maxSheild = PlayerPrefs.GetFloat("MaxSheild");
            sheild = maxSheild; 
            firePower = PlayerPrefs.GetInt("DamagePower");
            chargePower = PlayerPrefs.GetInt("ChargePower");
            criticleRate = PlayerPrefs.GetFloat("CriticRate");
        }       
        healthText.text = health + "/100%";
        sheildText.text = sheild + "/" + maxSheild + "%";
        criticText.text = criticleRate * 100 + "%";
    }

    private void Update()
    {
        GetHealth();
        GetSheild();
        GetMaxSheild();
        GetCritic();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SheildTimer();
    }

    private void SheildTimer()
    {
        if (sheild < maxSheild && Time.time > nextSheildRegenTimer)
        {
            sheild++;
            sheildText.text = sheild + "/" + maxSheild + "%";
        }
    }

    public void hitProcess(float realDamage)
    {
        nextSheildRegenTimer = Time.time + sheildRegenRate;
        sheild -= realDamage;
        StartCoroutine(cameraController.Shake(0.4f, 1.5f));
        healthText.text = health + "/100%";
        sheildText.text = sheild + "/" + maxSheild + "%";
        if (sheild < 0)
        {
            sheild = 0;
            health -= realDamage;
            if (health <= 0)
            {
                GameObject deatheffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(deatheffect, 3f);
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Healer")
        {
            float healAmount = FindObjectOfType<ItemHandler>().GetHealPower();
            if (health < maxHealth - healAmount)
            {
                health += healAmount;
                healthText.text = health + "/100%";
            }
            else
            {
                health = maxHealth;
                healthText.text = health + "/100%";
            }
        }
        else if (collision.tag == "Sheilder")
        {
            float addSheild = FindObjectOfType<ItemHandler>().GetSheildAmount();
            maxSheild += addSheild;
            sheildText.text = sheild + "/" + maxSheild + "%";
            if (maxSheild >= 100f)
            {
                maxSheild = 100f;
                sheildText.text = sheild + "/" + maxSheild + "%";
            }
        }
        else if (collision.tag == "PowerUpper")
        {
            float addCritic = FindObjectOfType<ItemHandler>().GetPowerUpDamage();
            if(criticleRate<1)
            {
                criticleRate += addCritic;
                criticText.text = criticleRate * 100 + "%";
            }
        }
    }


    public float GetHealth()
    {
        return health;
    }

    public float GetSheild()
    {
        return sheild;
    }

    public float GetMaxSheild()
    {
        return maxSheild;
    }

    public int GetFirePower()
    {
        return firePower;
    }

    public int GetChargePower()
    {
        return chargePower;
    }

    public float GetCritic()
    {
        return criticleRate;
    }
}