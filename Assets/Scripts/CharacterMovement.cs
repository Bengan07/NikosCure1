using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;
    public float moveSpeed = 10.0f; // Publik variabel för rörelsehastighet
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ta en kopia av spelarens position
        Vector3 playerPos = transform.position;

        // Rör spelaren uppåt om knappen "W" hålls ned
        if (Input.GetKey(KeyCode.W))
        {
            playerPos.y += moveSpeed * Time.deltaTime;
        }

        // Rör spelaren neråt om knappen "S" hålls ned
        if (Input.GetKey(KeyCode.S))
        {
            playerPos.y -= moveSpeed * Time.deltaTime;
        }

        // Rör spelaren åt höger om knappen "D" hålls ned
        if (Input.GetKey(KeyCode.D))
        {
            playerPos.x += moveSpeed * Time.deltaTime;
        }

        // Rör spelaren åt vänster om knappen "A" hålls ned
        if (Input.GetKey(KeyCode.A))
        {
            playerPos.x -= moveSpeed * Time.deltaTime;
        }

    }
}