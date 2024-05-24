using UnityEngine;

public class EnemyFlipScript : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            transform.localScale = new Vector2(1, -1);
        }

        if (player.position.y < transform.position.y)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
