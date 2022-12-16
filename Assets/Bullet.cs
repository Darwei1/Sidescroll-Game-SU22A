using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The speed at which the bullet will move
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the bullet
        Vector2 position = transform.position;

        // Compute the bullet's new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Update the bullet's position
        transform.position = position;

        // Get the screen height
        float screenHeight = Camera.main.orthographicSize * 2f;

        // If the bullet has moved off the screen, destroy it
        if (position.y > screenHeight)
        {
            Destroy(gameObject);
        }
    }
}
