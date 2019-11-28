using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float RotateSpeed = 120f;
    public float jumpForce = 1500;
    public float timeBeforeNextJump = 100f;
    private float canJump = 0f;
    private bool playerMoving = false;

    Animator animate;
    Rigidbody rigidBody;
    Quaternion savior;
    
    void Start()
    {
        animate = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControllPlayer();
    }


    void ControllPlayer()
    {
        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");

        //if(moveVertical < 0) moveVertical = 0;
        //movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // if (movement != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        //     anim.SetInteger("Walk", 1);
        // }
        // else {
        //     anim.SetInteger("Walk", 0);
        // }

        // transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        // if (Input.GetButtonDown("Jump") && Time.time > canJump)
        // {
        //         rb.AddForce(0, jumpForce, 0);
        //         canJump = Time.time + timeBeforeNextJump;
        //         anim.SetTrigger("jump");
        // }

        // Rotate Player
        if ( Input.GetKey(KeyCode.A) )
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
            playerMoving = true;
        }
        else if ( Input.GetKey(KeyCode.D) )
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
            playerMoving = true;
        }
        else playerMoving = false;

        // Move Player
        if ( Input.GetKey(KeyCode.W) )
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            playerMoving = true;
        }
        else if ( Input.GetKey(KeyCode.S) )
        {
            transform.position += -transform.forward * Time.deltaTime * movementSpeed;
            playerMoving = true;
        }
        else playerMoving = false;

        if (playerMoving) animate.SetInteger("Walk", 1);
        else animate.SetInteger("Walk", 0);
        
        // Jump Player
        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
            rigidBody.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            animate.SetTrigger("jump");
        }
    }

}