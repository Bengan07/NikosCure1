using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float DieTime = 3;

    public int MaxHealth = 3;
    public int CurrentHealth;

    bool isDying = false;

    EnemyFollowScript enemyFollowScript;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemyFollowScript = GetComponent<EnemyFollowScript>();
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        animator.SetBool("isDying", isDying);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            isDying = true;
            Invoke("RatGoByeBye", DieTime);
            enemyFollowScript.moveSpeedDuringAttack = 0f;
        }
    }
    void RatGoByeBye()
    {
        Destroy(gameObject);
    }
}
