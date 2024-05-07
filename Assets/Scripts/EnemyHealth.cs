using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 3;
    public int CurrentHealth;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
