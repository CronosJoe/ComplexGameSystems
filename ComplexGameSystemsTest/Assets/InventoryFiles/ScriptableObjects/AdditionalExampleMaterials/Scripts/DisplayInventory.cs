using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventoryToDisplay; //because we are using scriptables we can link directly to the inventory
    public int XStart;
    public int YStart;
    public int ColumnCount; //amount of columns in the display
    public int SpaceBetweenItemsXAxis;
    public int SpaceBetweenItemsYAxis;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void CreateDisplay()
    {
       for(int i =0;i<inventoryToDisplay.Container.Count; i++) 
        {
            GameObject tempDisplayObject = Instantiate(inventoryToDisplay.Container[i].item.prefab,Vector3.zero,Quaternion.identity,transform);
            tempDisplayObject.GetComponent<RectTransform>().localPosition = GetPosition(i); //sending in our index
            tempDisplayObject.GetComponentInChildren<TextMeshProUGUI>().text = inventoryToDisplay.Container[i].amount.ToString("n0");
        }
    }
    public Vector3 GetPosition(int index) 
    {
        return new Vector3(XStart + (SpaceBetweenItemsXAxis * (index % ColumnCount)), YStart + (-SpaceBetweenItemsYAxis * (index / ColumnCount)), 0f);
    }
}
