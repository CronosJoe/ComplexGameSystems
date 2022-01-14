﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item) 
        {
            inventory.AddItem(item.item, 1); //an example of how to add items
            Debug.Log("added item");
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear(); //let's you clear the items in an inventory
    }
}
