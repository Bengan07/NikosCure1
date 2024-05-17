using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    public Transform target; // The target the enemy will follow
    public float moveSpeed = 3f; // The speed at which the enemy moves
    public float stoppingDistance = 1f; // The distance at which the enemy stops moving

    public Transform player; // The player's transform

    private Camera mainCamera; // The main camera in the scene

    Rigidbody2D myRigidBody2D; // The enemy's rigidbody

    public bool isAttacking; // Flag indicating if the enemy is attacking

    void Start()
    {
        mainCamera = Camera.main;

        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // If the enemy is attacking, stop moving
        if (isAttacking)
        {
            moveSpeed = 0f;
        }

        // If the enemy is not attacking, move towards the target
        if (!isAttacking)
        {
            moveSpeed = 3f;
            if (target != null)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if (distanceToTarget > stoppingDistance)
                {
                    Vector3 direction = target.position - transform.position;
                    direction.Normalize();
                    transform.Translate(direction * moveSpeed * Time.deltaTime);
                }
            }
        }

        // If the target is not null, check if the enemy is visible on the screen
        if (target != null)
        {
            if (IsEnemyVisible())
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }

            // If the player is above the enemy, move towards the target
            if (player.position.y > transform.position.y)
                if (target != null)
                {
                    float distanceToTarget = Vector2.Distance(transform.position, target.position);
                    if (distanceToTarget > stoppingDistance)
                    {
                        Vector3 direction = target.position - transform.position;
                        direction.Normalize();
                        myRigidBody2D.velocity = direction * moveSpeed;
                    }
                    else
                    {
                        myRigidBody2D.velocity = Vector2.zero; // Stop moving
                    }
                }
            {
                FlipEnemy();
            }

            // If the player is below the enemy, flip the enemy's sprite
            if (player.position.y < transform.position.y)
            {
                FlipEnemyBack();
            }
        }
    }

    // Check if the enemy is visible on the screen
    bool IsEnemyVisible()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        return screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1 && screenPos.z > 0;
    }

    // Flip the enemy's sprite
    private void FlipEnemy()
    {
        transform.localScale = new Vector2(1, -1);
    }

    // Flip the enemy's sprite back
    private void FlipEnemyBack()
    {
        transform.localScale = new Vector2(1, 1);
    }
}
