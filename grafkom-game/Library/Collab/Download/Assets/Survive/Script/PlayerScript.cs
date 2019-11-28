using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Atribute
    public float moveSpeed = 6.0f;
    public float rotateSpeed = 120.0f;
    public float jumpForce = 300.0f;
    public float jumpDelay = 1.4f;
    private float canJump = 0;
    private bool playerMoving = false;

    // Position for Food
    public float x;
    public float y;
    public float z;

    // Displaying score 
    public Text countText;
    private float score;

    Animator animate;
    Rigidbody rigidBody;

    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        score = 0;
        countText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        x = Random.Range(-10, 10);
        y = -1;
        z = Random.Range(10, 20);
        Instantiate(obj, new Vector3(x, y, z), obj.transform.rotation);
        score = score + 1;
        countText.text = score.ToString();
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

        // Check Fall
        if( rigidBody.position.y < -5 )
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
