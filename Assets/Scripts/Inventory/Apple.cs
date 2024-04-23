using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, ICollectible
{
    public static event Action<ItemData> OnAppleCollected;
    public ItemData appleData;

    public void Collect()
    {
        Destroy(gameObject);
        OnAppleCollected?.Invoke(appleData);
    }
}
