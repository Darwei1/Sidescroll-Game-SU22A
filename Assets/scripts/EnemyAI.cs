using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    // The amount of health the enemy has
    public float maxHealth = 100f;

    // The current amount of health the enemy has
    private float currentHealth;

    // The speed at which the bullet will move in
    public float bulletVelocity = 10.0f;

    // The speed at which the enemy moves
    public float speed = 1.0f;

    // The distance that the enemy will move before turning around
    public float distance = 1.0f;

    // The distance at which the enemy can "see" the player
    public float sightDistance = 5.0f;

    // The frequency at which the enemy will shoot (in seconds)
    public float fireRate = 1.0f;

    // A reference to the player game object
    public GameObject player;

    // A reference to the enemy's bullet prefab
    public GameObject bulletPrefab;

    // The direction that the enemy is currently moving in
    // 1 is right, -1 is left
    private int direction = 1;

    // A timer for tracking when the enemy can fire again
    private float fireTimer = 0.0f;

    // The starting script when the game is launched
    public void Start()
    {

        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is within sight distance, start chasing them
        if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            // Increment the fire timer
            fireTimer += Time.deltaTime;

            // If the fire timer has reached the fire rate, reset it and fire a bullet
            if (fireTimer >= fireRate)
            {
                fireTimer = 0.0f;
                FireBullet();
            }
        }
        // Otherwise, move back and forth as before
        else
        {
            // Reset the fire timer
            fireTimer = 0.0f;

            // Move the enemy in the current direction
            transform.position += Vector3.right * direction * speed * Time.deltaTime;

            // If the enemy has moved further than the designated distance, turn around
            if (Mathf.Abs(transform.position.x) > distance)
            {
                direction *= -1;
            }
        }
    }

    // Function to instantiate and fire a bullet
    void FireBullet()
    {
        // Instantiate a new bullet at the enemy's position, facing towards the player
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.right = player.transform.position - transform.position;

        // Set the bullet's velocity
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bullet.transform.right * bulletVelocity;
    }

    // Function for the enemy to take damage
    public void TakeDamage(float damage)
    {

        // Reduce the current health of the enemy
        currentHealth -= damage;

        // if the enemy health reaches below 0 it will die!!
        if (currentHealth >= 0)
        {

            Destroy(gameObject);

        }

    }
}


