using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    [SerializeField] AudioClip upgradeSFX;
    [SerializeField] [Range(0, 1)] float upgradeVolume = 0.7f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(upgradeSFX, Camera.main.transform.position, upgradeVolume);
            Destroy(gameObject);
        }
    }
}
