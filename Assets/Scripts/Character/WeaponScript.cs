using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(1);
        }
    }
}
