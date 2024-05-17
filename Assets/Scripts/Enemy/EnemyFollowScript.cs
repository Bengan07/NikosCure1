using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    public Transform target;
    public float currentMoveSpeed;
    public float moveSpeed = 3f;
    public float stoppingDistance = 1f;

    public Transform player;

    private Camera mainCamera;

    Rigidbody2D myRigidBody2D;

    public bool isAttacking;
    void Start()
    {
        mainCamera = Camera.main;

        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAttacking)
        {
            currentMoveSpeed = 0f;
        }
        if (!isAttacking) 
        {
            currentMoveSpeed = moveSpeed;
        }
        if (target != null)
        {
            if (IsEnemyVisible())
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                transform.Translate(direction * currentMoveSpeed * Time.deltaTime);
            }
            if (player.position.y > transform.position.y)
            {
                FlipEnemy();
            }
            if (player.position.y < transform.position.y)
            {
                FlipEnemyBack();
            }
        }
        
    }

    bool IsEnemyVisible()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        return screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1 && screenPos.z > 0;
    }

    private void FlipEnemy()
    {
        transform.localScale = new Vector2(1, -1);
    }
    private void FlipEnemyBack()
    {
        transform.localScale = new Vector2(1, 1);
    }

    
}