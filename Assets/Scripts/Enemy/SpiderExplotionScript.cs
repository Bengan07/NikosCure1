using UnityEngine;

public class SpiderExplotionScript : MonoBehaviour
{
    public float spiderExplodeTime = 3;

    Animator animator;

    public int explotionDamage = 2;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("SpiderExplotionAnim");
            Invoke("SpiderExplode", spiderExplodeTime);
        }
    }
    void SpiderExplode()
    {
        Destroy(gameObject);
        gameObject.GetComponent<PlayerHealth>().TakeDamage(explotionDamage);
    }
}