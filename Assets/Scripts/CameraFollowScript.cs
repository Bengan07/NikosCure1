using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
