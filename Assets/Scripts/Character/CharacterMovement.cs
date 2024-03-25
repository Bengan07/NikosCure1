using System.Collections;
using UnityEngine;

public class Charactermovement : MonoBehaviour
{
    [SerializeField] float defaultMoveSpeed = 5f; // Default move speed
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float dashDistance = 5f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashCooldown = 2f;
    [SerializeField] float dashSpeed = 5f;
    private bool isDashing;

    Rigidbody2D myRigidBody;

    Vector2 moveDirection;
    float moveSpeed; // Current move speed

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = defaultMoveSpeed; // Initialize move speed to default value
    }

    //Reference to players animator
    public Animator anim;

    //The direction axis where the player is gonna move
    float horizontal;
    float vertical;

    void Update()
    { 
        //Getting the players input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Setting the animators parameters
        anim.SetFloat("X", horizontal);
        anim.SetFloat("Y", vertical);
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = defaultMoveSpeed; // Set it back to the default move speed when Left Shift is released
        }

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
            transform.Translate(dashDirection * dashDistance * dashSpeed * Time.fixedDeltaTime);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;
    }


}