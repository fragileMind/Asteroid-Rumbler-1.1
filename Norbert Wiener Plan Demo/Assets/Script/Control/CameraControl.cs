using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform playerTransform;
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = Game.Player.GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
        cameraTransform.position = new Vector3(playerTransform.position.x + 10, playerTransform.position.y + 14.14214f, playerTransform.position.z + 10);
        Debug.Log("CameraControl Activated");
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(playerTransform.position.x + 10, playerTransform.position.y + 14.14214f, playerTransform.position.z + 10);
    }
}
