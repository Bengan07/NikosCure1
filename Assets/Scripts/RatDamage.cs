using UnityEngine;

public class RatDamage : MonoBehaviour
{
    public float resetTime = 0.5f;
    bool isAttacking = false;
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
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            enemyFollowScript.isAttacking = true;
            Invoke("ResetIsAttacking", resetTime);
        }
    }

    void ResetIsAttacking()
    {
        enemyFollowScript.isAttacking = false;
    }

    private void Update()
    {
        animator.SetBool("isAttacking", isAttacking);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isAttacking = false;
    }
}