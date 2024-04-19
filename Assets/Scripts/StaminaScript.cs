using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10f;
    public float staminaRegenDelay = 1f;
    public float sprintStaminaConsumptionRate = 20f;

    private float regenTimer;

    void Start()
    {
        currentStamina = maxStamina;

        
    }

    void Update()
    {
        RegenerateStamina();
        HandleSprintInput();

        if (currentStamina <= 0)
        {
            
        }
    }

    void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= staminaRegenDelay)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }
        }
    }

    void HandleSprintInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float consumptionAmount = sprintStaminaConsumptionRate * Time.deltaTime;
            ConsumeStamina(consumptionAmount);
        }
    }

    public void ConsumeStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        regenTimer = 0f;
    }
}
