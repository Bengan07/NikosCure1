using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float defaultMoveSpeed = 5f; // Default move speed
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float dashDistance = 5f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] public float dashCooldown = 2f;
    [SerializeField] float dashSpeed = 5f; // Speed of the dash
    private bool isDashing;
    private bool isColliding;

    Rigidbody2D myRigidBody;

    StaminaScript staminaScript;

    Vector2 moveDirection;
    float moveSpeed; // Current move speed

    private void Start()
    {
        staminaScript = GetComponent<StaminaScript>();
        myRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = defaultMoveSpeed; // Initialize move speed to default value
    }

    void Update()
    {
        if (staminaScript.currentStamina > 0 && !isDashing)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = runSpeed; // Set move speed to run speed
            }
            // Check if Space key is pressed and not currently dashing
            if (Input.GetKey(KeyCode.Space) && !isDashing)
            {
                StartCoroutine(Dash()); // Start the dash coroutine
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = defaultMoveSpeed; // Set move speed back to default value
        }
        if (staminaScript.currentStamina == 0)
        {
            moveSpeed = defaultMoveSpeed;
        }

        // Handle character movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); // Set the velocity of the rigidbody based on move direction and move speed
    }

    IEnumerator Dash()
    {
        isDashing = true;

        Vector3 dashDirection = moveDirection;

        float timeElapsed = 0f;
        while (timeElapsed < dashTime)
        {
            if (isColliding)
            {
                isDashing = false;
                yield break;
            }

            transform.Translate(dashDirection * dashDistance * dashSpeed * Time.fixedDeltaTime);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}