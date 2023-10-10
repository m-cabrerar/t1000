using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private const KeyCode NEXT_ITEM = KeyCode.E;
    private const KeyCode PREV_ITEM = KeyCode.Q;
    private int selectedPos = -1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedPos != -1)
            {
                ItemData itemData = inventory.GetItems()[selectedPos];
                Debug.Log(itemData.itemName);
            }
        }
        
        if (Input.GetKeyDown(NEXT_ITEM))
        {
            itemSelect(true);
        }
        else if (Input.GetKeyDown(PREV_ITEM))
        {
            itemSelect(false);
        }
        
    }

    public void itemSelect(bool next)
    {
        if (next)
        {
            selectedPos++;
            if (selectedPos >= inventory.GetItems().Count)
                selectedPos = 0;
        }
        else
        {
            selectedPos--;
            if (selectedPos < 0)
                selectedPos = inventory.GetItems().Count - 1;
        }
    }
    
    public Inventory GetInventory() { return inventory; }
}
