using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour { 





    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            Vector3 checkPointPosition = transform.position;
            PlayerPrefs.SetFloat("transformX", checkPointPosition.x);
            PlayerPrefs.SetFloat("transformY", checkPointPosition.y);
            PlayerPrefs.SetFloat("transformZ", checkPointPosition.z);
        }
    }
}
