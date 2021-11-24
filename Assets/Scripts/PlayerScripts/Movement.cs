using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] float moveSpeed = 80f;
    [SerializeField] float rotatePower = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput();
        rotateInput();
    }

    void moveInput()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 newDirection = new Vector2(inputX, inputY);

        rb2d.AddForce(newDirection * moveSpeed * Time.deltaTime);

    }

    void rotateInput()
    {
        if (Input.GetKey(KeyCode.K))
        {
            rotateProcess(rotatePower);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            rotateProcess(-rotatePower);
        }
    }
    void rotateProcess(float rotateThisFrame)
    {
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
    }
}