using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Sprite[] heartsSprites; // Array of heart sprites for the health bar

    int currentHealthSpriteIndex = 0; // Index of the current heart sprite

    UI ui;
    Image healthBar;

    public bool isBlocking = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; // Set the initial health value

        ui = FindObjectOfType<UI>(); // Find the UI script in the scene

        healthBar = ui.GetComponentInChildren<Image>(); // Get the health bar image component

        healthBar.sprite = heartsSprites[currentHealthSpriteIndex]; // Set the initial heart sprite

        health = maxHealth; // Set the initial health value
    }

    // Update is called once per frame
    void Update()
    {
        if (health < maxHealth)
        {
            StartCoroutine(AddHealthOverTime(5f)); // Call the coroutine to add health over time
        }
    }

    public int health; // Current health value
    public int maxHealth = 3; // Maximum health value

    // Function to take damage
    public void TakeDamage(int amount)
    {
        if (!isBlocking)
        {
            if (currentHealthSpriteIndex < heartsSprites.Length - 1)
            {
                currentHealthSpriteIndex++; // Decrease the index of the current heart sprite
                healthBar.sprite = heartsSprites[currentHealthSpriteIndex]; // Update the health bar sprite
            }

            health -= amount; // Decrease the health value

            if (health <= 0)
            {
                Destroy(gameObject); // Destroy the player character if health reaches zero
            }
        }
    }

    // Coroutine to add health over time
    private IEnumerator AddHealthOverTime(float duration)
    {
        float elapsedTime = 0f; // Elapsed time since the coroutine started

        while (elapsedTime < duration)
        {
            yield return null; // Wait for the next frame

            elapsedTime += Time.deltaTime; // Increase the elapsed time

            if (elapsedTime >= duration)
            {
                AddHealth(1); // Add health when the duration is reached
            }
        }
    }

    // Function to add health
    public void AddHealth(int amount)
    {
        if (currentHealthSpriteIndex > 0)
        {
            currentHealthSpriteIndex--; // Increase the index of the current heart sprite
            healthBar.sprite = heartsSprites[currentHealthSpriteIndex]; // Update the health bar sprite
        }

        health += amount; // Increase the health value

        if (health > maxHealth)
        {
            health = maxHealth; // Cap the health value at the maximum
        }
    }

    // Function called when colliding with a health zone
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthZone"))
        {
            AddHealth(1); // Add health when colliding with a health zone
        }
    }
}
