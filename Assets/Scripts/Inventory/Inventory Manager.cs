using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(1);

    void ResetInventory()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots.Clear();
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++)
        {
            // Create the slot
            CreateInventorySlot();
        }
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }
}


