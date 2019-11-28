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
    private float x;
    private float y;
    private float z;
    private int choose;
    private int test_choose;
    private Vector3[] foodPosition;

    // Displaying score
    public Text countText;
    private int score;

    Animator animate;
    Rigidbody rigidBody;

    // Game Object Food
    public GameObject obj;

    // Progress Bar
    public Image progbar;
    private float progbarWidth;

    // Script score data
    public ScoreScript scoreScript;
    
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        // Set Score
        score = 0;
        countText.text = "Score : " + score.ToString();

        // Food Position
        foodPosition = new Vector3[6];
        foodPosition[0] = new Vector3(-1f,-1f,10f);
        foodPosition[1] = new Vector3(12f,0f,36f);
        foodPosition[2] = new Vector3(67f,2f,40f);
        foodPosition[3] = new Vector3(35f,3f,113f);
        foodPosition[4] = new Vector3(3f,1f,58f);
        foodPosition[5] = new Vector3(-50f,4f,96f);

        // Progress Bar Width
        progbarWidth = 160.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
        UpdateProgressBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destory object
        Destroy(other.gameObject);

        // Choose random positition from given array
        test_choose = Random.Range(0,6);
        if(test_choose == choose) choose = (test_choose + 1) % 6;
        else choose = test_choose;

        x = foodPosition[choose].x;
        y = foodPosition[choose].y;
        z = foodPosition[choose].z;

        // Create food object
        Instantiate(obj, new Vector3(x, y, z), obj.transform.rotation);
        
        // Add score
        score = score + 1;
        countText.text = "Score : " + score.ToString();
        SaveScore();

        // Set Progress Bar full again
        progbarWidth = 160.0f;
    }

    void OnCollisionEnter(Collision other) 
    {
        if( other.collider.tag == "Enemy" )
        {
            // Save score
            SaveScore();

            // Go to End Menu
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Saving score to script
    void SaveScore()
    {
        scoreScript.scoreValue = score;
    }

    // Progress Bar Update
    void UpdateProgressBar()
    {
        progbarWidth = progbarWidth - 0.1f;
        progbar.rectTransform.sizeDelta = new Vector2(progbarWidth, 18.0f);

        // If player hunger below zero, player is dead
        if(progbarWidth < 0.0f) 
        {
            // Save score
            SaveScore();

            // Go To End Menu
            FindObjectOfType<GameManager>().EndGame();
        }
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
            // Save score
            SaveScore();

            // Go To End Menu
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
