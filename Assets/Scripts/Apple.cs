using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, ICollectible
{
    public static event Action OnAppleCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnAppleCollected?.Invoke();
    }
}
