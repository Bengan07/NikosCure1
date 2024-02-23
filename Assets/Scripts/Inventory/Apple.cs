using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Apple : MonoBehaviour, ICollectible
{
    public static event HandleAppleCollected OnAppleCollected;
    public static event Action OnAppleCollected;
    public delegate void HandleAppleCollected(ItemData itemData);
    public ItemData appleData;

 
    public void Collect()
    {
        Destroy(gameObject);
        OnAppleCollected?.Invoke(appleData);
    }
}
