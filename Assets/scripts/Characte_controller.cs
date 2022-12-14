using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characte_controller : MonoBehaviour
{

    [Header("Keybinds")]
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Sprint;
    public KeyCode Jump;

    [Header("Movement Variables")]
    public float walk;
    public float sprint;
    public float jumpForce;


    Rigidbody2D rb;


    void awake()
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
            transform.position -= new Vector3(walk, 0 , 0)* sprint * Time.deltaTime;
        }

        // Right Movement
        else if (Input.GetKey(Right))
        {
            transform.position += new Vector3(walk, 0 , 0)* sprint * Time.deltaTime;
        }

        //  Jumping
        if (Input.GetKeyDown(KeyCode.W))
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

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
