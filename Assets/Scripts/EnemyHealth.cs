using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 3;
    public int CurrentHealth;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (CurrentHealth<3)
        {
            Debug.Log("Enemy took Damage");
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
