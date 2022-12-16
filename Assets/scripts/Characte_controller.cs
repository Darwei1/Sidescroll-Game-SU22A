using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characte_controller : MonoBehaviour
{
    // These are to store the information of the variables
    [Header("Movement Variables")]
    public float walk;
    public float sprint;
    public float jumpForce;

    // checks if the character is grounded
    public bool isGrounded = true;

    // imports rigidbody
    Rigidbody2D rb;

    // Gets the amount of health for our character
    public int maxHealth = 100;
    public int currentHealth; 


    void Awake()
    {

        // gets the component rigidbody2d from the character
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Sprinting, This basically does so that while we hold shift the sprint will be changed from 1 to 2. Doubling the player speed.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 2;
        }
        else
        {
            sprint = 1;
        }

        // Left Movement
        if (Input.GetKey(KeyCode.A))
        {
            // move the player in the left direction
            transform.position -= new Vector3(walk, 0, 0) * sprint * Time.deltaTime;
        }

        // Right Movement
        else if (Input.GetKey(KeyCode.D))
        {
            // Move the player in the right direction
            transform.position += new Vector3(walk, 0, 0) * sprint * Time.deltaTime;
        }

        // Check if the player is on the ground
        if (isGrounded)
        {
            // Check for jump input
            if (Input.GetKeyDown(KeyCode.Space))
            {

                // Add force to the player's Rigidbody
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                // Set isGrounded to false to prevent multiple jumps
                isGrounded = false;

            }
        }
    }


    public void Shoot()
    {



    }



    // Checks for character collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // if our character collides with the tag Platform, isGrounded is changed to true.
        if (collision.transform.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        

    }

}
