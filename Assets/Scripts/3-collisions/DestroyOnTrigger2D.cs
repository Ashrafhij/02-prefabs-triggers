using TMPro;
using UnityEngine;

/**
 * This component reduces the spaceship's health whenever it triggers a 2D collider with the given tag.
 * The spaceship is destroyed after a certain number of collisions.
 * It also updates the health display using the HealthDisplay script.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the reduction of spaceship's health")]
    [SerializeField] string triggeringTag;

    [Tooltip("Maximum number of collisions allowed before the spaceship is destroyed")]
    [SerializeField] int maxCollisions = 3;

    private int currentCollisions = 0;

    private void Start()
    {

        // Set initial health
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            // Reduce the spaceship's health
            currentCollisions++;

            // Update health display

            // Check if the maximum number of collisions has been reached
            if (currentCollisions >= maxCollisions)
            {
                // Destroy the spaceship
                Destroy(this.gameObject);
            }

            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
