using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float maxBlocks = 3;
    public float currentBlocks;
    public float blockRechargeTime = 2f;
    private float blockRechargeTimer = 0f;

    bool isRecharging;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        currentBlocks = maxBlocks;
    }

    void Update()
    {
        if (currentBlocks > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerHealth.isBlocking = true;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                playerHealth.isBlocking = false;
            }
        }
        if (isRecharging)
        {
            blockRechargeTimer += Time.deltaTime;
            if (blockRechargeTimer >= blockRechargeTime)
            {
                // Reset timer and stop recharging
                blockRechargeTimer = 0f;
                isRecharging = false;
                // Refill blocks
                currentBlocks = maxBlocks;
            }
        }
        if (currentBlocks <= 0)
        {
            playerHealth.isBlocking = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentBlocks--;
        }
    }
}
