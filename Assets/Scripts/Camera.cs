using UnityEngine;
using System.Collections;



public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector2 boundariesMax;
    public Vector2 boundariesMin;

    void LateUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.z = transform.position.z;

        newPosition.x = Mathf.Clamp(newPosition.x, boundariesMin.x, boundariesMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, boundariesMin.y, boundariesMax.y);

        transform.position = newPosition;
    }

    public void SetBoundaries(Vector2 newBoundaries)
    {
        //boundaries = newBoundaries;
    }
}


