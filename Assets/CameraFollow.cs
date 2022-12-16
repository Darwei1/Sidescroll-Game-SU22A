using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object to follow
    public float followDistance; // The distance at which the camera starts following the target
    public float followSpeed; // The speed at which the camera moves towards the target
    private Vector3 targetPosition; // The position the camera should move towards

    public float minX; // The minimum x coordinate the camera can have
    public float maxX; // The maximum x coordinate the camera can have
    public float minY; // The minimum y coordinate the camera can have
    public float maxY; // The maximum y coordinate the camera can have

    void LateUpdate()
    {
        // Clamp the camera's position to the min and max values
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
    }


    // Update is called once per frame
    void Update()
    {
        // If the target is further than the follow distance from the camera
        if (Vector3.Distance(transform.position, target.position) > followDistance)
        {
            // Set the target position to be the target's position
            targetPosition = target.position;
        }

        // Move the camera towards the target position at the follow speed
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
