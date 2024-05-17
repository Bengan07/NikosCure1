using UnityEngine;

public class SpiderExplotioningScript : MonoBehaviour
{
    public float byebyeTime = 3;

    bool isExplotioning = false;

    Animator animator;

    public int explotioningDamage = 2;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on child objects");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isExplotioning = true;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(explotioningDamage);
            Invoke("SpiderGoByeBye", byebyeTime);
        }
    }
    void SpiderGoByeBye()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        animator.SetBool("isExplotioning", isExplotioning);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isExplotioning = false;
        }
    }
}
