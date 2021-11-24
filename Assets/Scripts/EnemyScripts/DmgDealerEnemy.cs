using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DmgDealerEnemy : MonoBehaviour
{
    [SerializeField] float enemydamage = 20f;
    [SerializeField] float stageMultiplier = 1.2f;
    [SerializeField] float realDamage;

    int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneMultiplier = sceneIndex - 1;
        realDamage = enemydamage * Mathf.Pow(stageMultiplier, sceneMultiplier);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == ("Player"))
        {
            hitInfo.GetComponent<UnitCollisionPlayer>().hitProcess(realDamage);
            Destroy(gameObject);
        }
    }
}