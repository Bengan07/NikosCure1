using System.Collections;
using UnityEngine;

public class Charactermovement : MonoBehaviour
{
    [SerializeField] float defaultMoveSpeed = 5f; // Default move speed
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float dashDistance = 5f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashCooldown = 2f;
    [SerializeField] float dashSpeed = 5f; // Speed of the dash
    private bool isDashing;

    Rigidbody2D myRigidBody;

    Vector2 moveDirection;
    float moveSpeed; // Current move speed

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = defaultMoveSpeed; // Initialize move speed to default value
    }

    void Update()
    {
        // Check if Left Shift key is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed; // Set move speed to run speed
        }
        // Check if Left Shift key is released
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = defaultMoveSpeed; // Set move speed back to default value
        }

        // Check if Space key is pressed and not currently dashing
        if (Input.GetKey(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash()); // Start the dash coroutine
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
            transform.Translate(dashDirection * dashDistance * dashSpeed * Time.fixedDeltaTime); // Translate the transform based on dash direction, dash distance, dash speed, and fixed delta time
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }
}
