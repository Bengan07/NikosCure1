using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;
    public float moveSpeed = 10.0f; // Publik variabel f�r r�relsehastighet
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ta en kopia av spelarens position
        Vector3 playerPos = transform.position;

        // R�r spelaren upp�t om knappen "W" h�lls ned
        if (Input.GetKey(KeyCode.W))
        {
            playerPos.y += moveSpeed * Time.deltaTime;
        }

        // R�r spelaren ner�t om knappen "S" h�lls ned
        if (Input.GetKey(KeyCode.S))
        {
            playerPos.y -= moveSpeed * Time.deltaTime;
        }

        // R�r spelaren �t h�ger om knappen "D" h�lls ned
        if (Input.GetKey(KeyCode.D))
        {
            playerPos.x += moveSpeed * Time.deltaTime;
        }

        // R�r spelaren �t v�nster om knappen "A" h�lls ned
        if (Input.GetKey(KeyCode.A))
        {
            playerPos.x -= moveSpeed * Time.deltaTime;
        }

    }
}