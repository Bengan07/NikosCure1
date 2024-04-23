using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerHealth.isBlocking = true;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            playerHealth.isBlocking = false;
        }
    }

}
