using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float maxBlocks = 3;
    public float currentBlocks;
    public float blockRechargeTime = 2f;
    public float maxParrys = 1;
    public float currentParrys;
    public float parryRechargeTime = 1f;
    public float blockMoveSpeed = 2;

    public int parryDamage = 1;

    PlayerHealth playerHealth;

    public RatDamage rat;
    public EnemyHealthScript enemyHealth;
    CharacterMovement characterMovement;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        characterMovement = GetComponent<CharacterMovement>();

        currentBlocks = maxBlocks;
        currentParrys = maxParrys;
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
        if (currentBlocks <= 0)
        {
            playerHealth.isBlocking = false;
            Invoke("blockRecharge", blockRechargeTime);
        }
        if (!playerHealth.isBlocking && rat.isAttacking && currentParrys > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                enemyHealth.TakeDamage(parryDamage);
                currentParrys--;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Invoke("ParryRecharge", parryRechargeTime);
        }
    }

    void ParryRecharge()
    {
        currentParrys = maxParrys;
    }

    void blockRecharge()
    {
        currentBlocks = maxBlocks;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentBlocks--;
        }
    }
}
