using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // The minimum amount of damage that the bullet will do
    public float minDamage = 10.0f;

    // The maximum amount of damage that the bullet will do
    public float maxDamage = 20.0f;

    // A reference to the enemy AI script
    private EnemyAI enemyAI;

    void Start()
    {
        // Get a reference to the enemy AI script
        enemyAI = GetComponent<EnemyAI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an enemy, deal a random amount of damage to the enemy
        if (collision.gameObject.tag == "Enemy")
        {
            float damage = Random.Range(minDamage, maxDamage);
            enemyAI.TakeDamage(damage);
        }
    }
}
