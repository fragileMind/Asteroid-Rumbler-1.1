using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarwithCollision : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxHealth = 100;

    public GameObject healthBarUI;
    public Slider slider;
   

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hitProcess(int damage)
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }

        float CalculateHealth()
        {
            return health / maxHealth;
        }

    }
}        