using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    public Transform target;
    public float moveSpeedDuringAttack = 0f;
    public float moveSpeed = 3f;
    public float originalMoveSpeed;
    public float stoppingDistance = 1f;

    private Camera mainCamera;

    public bool isAttacking = false;

    void Start()
    {
        mainCamera = Camera.main;

        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            if (IsEnemyVisible())
            {
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
    }
    bool IsEnemyVisible()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        return screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1 && screenPos.z > 0;
    }
}
