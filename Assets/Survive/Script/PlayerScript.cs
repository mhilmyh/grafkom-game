using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Atribute
    public float moveSpeed = 6.0f;
    public float rotateSpeed = 120.0f;
    public float jumpForce = 300.0f;
    public float jumpDelay = 1.4f;
    private float canJump = 0;
    private bool playerMoving = false;

    Animator animate;
    Rigidbody rigidBody;

    
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    // Controller method
    void Controller()
    {
        // Move
        if ( Input.GetKey(KeyCode.W) )
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            playerMoving = true;
        }
        else if ( Input.GetKey(KeyCode.S) )
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            playerMoving = true;
        }
        else playerMoving = false;

        // Animation
        if ( playerMoving ) animate.SetInteger("Walk", 1);
        else animate.SetInteger("Walk", 0);

        // Rotate
        if ( Input.GetKey(KeyCode.A) )
        {
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            playerMoving = true;
        }
        else if ( Input.GetKey(KeyCode.D) )
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            playerMoving = true;
        }
        else playerMoving = false;

        // Jump
        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
            rigidBody.AddForce(0, jumpForce, 0);
            canJump = Time.time + jumpDelay;
            animate.SetTrigger("jump");
        }
    }
}
