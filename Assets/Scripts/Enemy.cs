using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public Rigidbody2D myRigidBody = null;
    public PlayerHealth CurrentPlayerHealth = null;
    public GameObject OffScreenChecker = null; // Publik variabel för att lagra OffScreenChecker
    public float MoveSpeed = 10.0f; // Public variabel for speed


    public void DealDamage()
    {
        CurrentPlayerHealth.health -= 1;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerComp = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerComp != null)
        {
            DealDamage();
        }
    }
    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
