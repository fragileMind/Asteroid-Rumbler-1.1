using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(PlayerPrefs.HasKey("transformX"))
        {
            Vector3 lastCheckPoint =new Vector3(PlayerPrefs.GetFloat("transformX"), PlayerPrefs.GetFloat("transformY"), PlayerPrefs.GetFloat("transformZ"));
            player.transform.position = lastCheckPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
