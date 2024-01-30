using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Charactermovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dashDistance = 5f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashCooldown = 2f;
    [SerializeField] float dashSpeed = 5f;
    private bool isDashing;

    Rigidbody2D myRigidBody;

    Vector2 moveDirection;
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKey(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    IEnumerator Dash()
    {
        isDashing = true;

        Vector3 dashDirection = moveDirection;

        float timeElapsed = 0f;
        while (timeElapsed < dashTime)
        {
            transform.Translate(dashDirection * dashDistance * dashSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }
}

