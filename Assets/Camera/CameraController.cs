using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed=0.125f;
    [SerializeField] Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()  //update later after updates
    {if (GameObject.FindGameObjectWithTag("Player") == true)
        {
            Vector3 desiredPosition = target.position + offset;  //calculate camera position while player moving.
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //give a smooth movement to camera.
            transform.position = smoothPosition;
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;
        Vector3 originOffset = offset;
        while(elapsed<duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            offset = new Vector3(x, y, -300);

            elapsed += Time.deltaTime;
            yield return null;
        }

        offset = originOffset;
    }
}
