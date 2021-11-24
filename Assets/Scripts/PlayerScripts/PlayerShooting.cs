using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject pfBullet;
    [SerializeField] float firePeriod=1f;
   

    Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireInput();
    }

    void fireInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            firingCoroutine=StartCoroutine(fireContinuously());
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator fireContinuously()
    {
        while (true)
        {
            Instantiate(pfBullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(firePeriod);
        }

    }
}
