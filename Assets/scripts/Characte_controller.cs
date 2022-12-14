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
        rb.freezeRotation = true;
        
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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * sprint * Time.deltaTime;
        }

        // Right Movement
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * sprint * Time.deltaTime;
        }

        //  Jumping
        if (Input.GetKeyDown(Jump))
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }


        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {


    }

}
