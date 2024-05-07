using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 3;
    public int CurrentHealth;

    bool isDying = false;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            isDying = true;

            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
