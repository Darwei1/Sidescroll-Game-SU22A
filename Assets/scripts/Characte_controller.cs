using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characte_controller : MonoBehaviour
{
    // This is for easy change of a keybind 
    [Header("Keybinds")]
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Sprint;
    
    // These are to store the information of the variables
    [Header("Movement Variables")]
    public float walk;
    public float sprint;
    public float jumpForce;

    [Header("Advanced Movement")]
    bool isGrounded = true;

    Rigidbody2D rb;


    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Sprinting
        if (Input.GetKey(Sprint))
        {
            sprint = 2;
        }
        else
        {
            sprint = 1;
        }

        // Left Movement
        if (Input.GetKey(Left))
        {
            // move the player in the left direction
            transform.position -= new Vector3(walk, 0 , 0)* sprint * Time.deltaTime;
        }

        // Right Movement
        else if (Input.GetKey(Right))
        {
            // Move the player in the right direction
            transform.position += new Vector3(walk, 0 , 0)* sprint * Time.deltaTime;
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

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {

            // Sends signal to start the actuall Shoot code
            Shoot();

        }

    }

    void Shoot()
    {


    }

}
