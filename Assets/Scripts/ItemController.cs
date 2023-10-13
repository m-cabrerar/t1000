using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        InventoryController.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
