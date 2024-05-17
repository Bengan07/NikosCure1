using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float KnockbackForce = 10f;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealthScript enemyHealth = collision.gameObject.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(1);
        }
    }
}
