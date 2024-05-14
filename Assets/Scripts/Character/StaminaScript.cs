using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    public float currentStamina;
    public float maxStamina = 100;
    public float staminaDrainRate = 5f;
    public float staminaRegenRate = 5f;
    public float dashStaminaCost = 10;
    public float staminaRegenTimer = 2f;

    CharacterMovement charactermovement;

    void Start()
    {
        currentStamina = maxStamina;

        charactermovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && currentStamina > 10 && charactermovement.dashCooldown == 0)
        {
            currentStamina -= dashStaminaCost;
        }

        Invoke("StaminaRegen", staminaRegenTimer);

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    void StaminaRegen()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }
    }
}