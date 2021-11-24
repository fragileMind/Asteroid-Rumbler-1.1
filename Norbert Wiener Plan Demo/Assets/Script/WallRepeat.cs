using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRepeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = GetComponent<Transform>().localScale.x;
        float z = GetComponent<Transform>().localScale.z;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2((x > z ? x : z) / 2.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
