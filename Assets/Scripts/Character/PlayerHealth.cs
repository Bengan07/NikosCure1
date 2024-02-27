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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        currentHealthSpriteIndex++;
        healthBar.sprite = heartsSprites[currentHealthSpriteIndex];

        // Damage and death here
    }
}
