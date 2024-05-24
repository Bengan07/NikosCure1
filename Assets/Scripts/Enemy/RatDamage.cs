using UnityEngine;

public class RatDamage : MonoBehaviour
{
    public float resetTime = 0.5f;
    public bool isAttacking = false;

    Animator animator;
    EnemyFollowScript enemyFollowScript;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemyFollowScript = GetComponent<EnemyFollowScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            enemyFollowScript.isAttacking = true;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            Invoke("ResetIsAttacking", resetTime);
            enemyFollowScript.moveSpeed = enemyFollowScript.moveSpeedDuringAttack;
        }
    }

    void ResetIsAttacking()
    {
        isAttacking = false;
    }

    private void Update()
    {
        animator.SetBool("isAttacking", isAttacking);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isAttacking = false;
        Invoke("AttackMoveSpeedResetTime", resetTime);
    }
    void AttackMoveSpeedResetTime()
    {
        enemyFollowScript.moveSpeed = enemyFollowScript.originalMoveSpeed;
    }
}