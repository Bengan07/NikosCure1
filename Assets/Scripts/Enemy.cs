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

    [SerializeField]
    Transform player;


    [SerializeField]
    float agroRange;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print ("Distance to player: " + distToPlayer);
        //if (distToPlayer < agroRange)
        {
            //Vector2 direction = player.position - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb2d.rotation = angle;
            //direction.Normalize();
            //MoveCharacter(direction);
        }
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
