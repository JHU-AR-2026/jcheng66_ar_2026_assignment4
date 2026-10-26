
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 6f;

    // Power-up setup
    public GameObject powerUp;
    public int totalCollectibles = 8;

    public GameObject powerUpText;
    public bool powerUpActive = false;

    public GameObject winText;
    public TextMeshProUGUI collectibleText;

    private int collectedCount = 0;

    private Rigidbody rb;
    private float moveX;
    private float moveZ;

    private bool gameStarted = false;
    private bool isGrounded = false;
    private bool jumpRequested = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void Update()
    {
        if (!gameStarted)
            return;

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (!gameStarted)
            return;

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(movement * speed);

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce,
                        ForceMode.Impulse);

            jumpRequested = false;
            isGrounded = false;
        }
    }

    public void StartGame()
    {
        gameStarted = true;

        rb.isKinematic = false;
        rb.useGravity = true;
        collectibleText.text = "Collected: " + collectedCount + "/" + totalCollectibles;

        Debug.Log("Game Started!");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    
    
    private void OnTriggerEnter(Collider other)
    {   
        if (!gameStarted)
            return;

        // Collectible cubes
        if (other.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            collectedCount++;

            Debug.Log("Collected: " + collectedCount + "/" + totalCollectibles);


            collectibleText.text = "Collected: " + collectedCount + "/" + totalCollectibles;


            if (collectedCount >= totalCollectibles)
            {
                powerUp.SetActive(true);
                Debug.Log("Power-up appeared!");
            }
        }

        // Power-up capsule
        else if (other.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);

            powerUpActive = true;
            speed *= 4f;

            GetComponent<Renderer>().material.color = Color.magenta;

            powerUpText.SetActive(true);

            Debug.Log("POWER-UP ACTIVATED!");
        }

        // Goal zone
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");

            // Hide power-up message
            powerUpText.SetActive(false);

            // Show win message
            winText.SetActive(true);

            // Hide player and disable movement
            gameStarted = false;
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!gameStarted)
            return;

        if (collision.gameObject.CompareTag("SpecialWall"))
        {
            if (powerUpActive)
            {
                // Break the wall only if powered up
                collision.gameObject.SetActive(false);

                Debug.Log("Special wall broken!");
            }
            else
            {
                Debug.Log("Power-up required to break this wall!");
            }
        }
    }


}
