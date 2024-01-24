using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the reduction of health")]
    [SerializeField] string triggeringTag;

    [Tooltip("Maximum number of shots allowed before the object is destroyed")]
    [SerializeField] int maxShots = 3;

    [Tooltip("Reference to the UI Text component for displaying health")]
    [SerializeField] TextMesh healthText;

    [Tooltip("Reference to the UI Text component for displaying health")]
    public Text healthText2; // This line declares healthText as a public variable of type Text


    private int currentShots = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            // Increase the shot count
            currentShots++;

            // Update health text
            UpdateHealthText();

            // Check if the maximum number of shots has been reached
            if (currentShots >= maxShots)
            {
                Destroy(this.gameObject); // Destroy the object
            }

            Destroy(other.gameObject); // Destroy the colliding object (e.g., bullet)
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            // Update the health text
            healthText.text = "Health: " + (maxShots - currentShots);
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
