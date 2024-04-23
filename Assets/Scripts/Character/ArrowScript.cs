using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;
    public float MoveSpeed = 10.0f; // Publik variabel för rörelsehastighet

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(MoveSpeed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > 265.0f)
        {
            if (gameObject != null)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyComp = collision.gameObject.GetComponent<Enemy>();
        if (enemyComp != null)
        {
            enemyComp.TakeDamage();

            GameObject.Destroy(gameObject);
        }
    }
}