using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTimer : MonoBehaviour
{
    public float timeToDelete; // The time it takes for the object to delete itself
    private float timer; // A timer to track the time until delete

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // If the timer is greater than or equal to the time to delete
        if (timer >= timeToDelete)
        {
            // Destroy the game object
            Destroy(gameObject);
        }
    }
}
