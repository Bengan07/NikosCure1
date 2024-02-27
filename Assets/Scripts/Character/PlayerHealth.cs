using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   
    [SerializeField] Sprite[] heartsSprites;

    int currentHealthSpriteIndex = 0;



    UI ui;
    Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UI>();

        healthBar = ui.GetComponentInChildren<Image>();

        healthBar.sprite = heartsSprites[currentHealthSpriteIndex];

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
    public int health;
    public int maxHealth = 3;

    public void TakeDamage(int amount)
    {
        if (currentHealthSpriteIndex < heartsSprites.Length - 1)
        {
            currentHealthSpriteIndex++;
            healthBar.sprite = heartsSprites[currentHealthSpriteIndex];
        }

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
   
    
}
