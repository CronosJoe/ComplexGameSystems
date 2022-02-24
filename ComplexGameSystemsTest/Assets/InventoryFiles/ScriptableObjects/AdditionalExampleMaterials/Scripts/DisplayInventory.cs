using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventoryToDisplay; //because we are using scriptables we can link directly to the inventory
    public List<CellSlot> inventoryCells = new List<CellSlot>();
    public List<GameObject> inventoryDisplay = new List<GameObject>();
    public GameObject defaultCellImage;
    public float XStart;
    public float YStart; //these should become the top left corner of our inventory display
    public int ColumnCount; //amount of columns in the display
    public int SpaceBetweenItemsXAxis;
    public int SpaceBetweenItemsYAxis;

    private void Start()
    {
        CreateDisplay(); //this will be moved to a different call when sample scenes are set up
    }

    private void CreateDisplay()
    {
        //create cells
        for (int i = 0; i < inventoryToDisplay.inventorySize; i++) 
        {
            inventoryCells.Add(new CellSlot(0, defaultCellImage)); //defaulting each cell to have nothing this will be set up in the update display   
        }
        GameObject tmp = Instantiate(inventoryCells[0].ImageToDisplay, this.transform, false);
        XStart = tmp.GetComponent<RectTransform>().anchoredPosition.x;
        YStart = tmp.GetComponent<RectTransform>().anchoredPosition.y;
        inventoryDisplay.Add(tmp);
        for(int i = 1; i < inventoryCells.Count; i++) 
        {
            GameObject tmpCell = Instantiate(inventoryCells[i].ImageToDisplay, this.transform, false);
            tmpCell.GetComponent<RectTransform>().anchoredPosition = GetPosition(i);
            inventoryDisplay.Add(tmpCell);
        }
        UpdateDisplay();
    }
    private void UpdateDisplay() 
    {
        //for(int i = 0; i < inventoryCells.Count; i++)
        //{
        //    if (i<inventoryToDisplay.Container.Count) 
        //    {
        //        inventoryCells[i].AmountToDisplay = inventoryToDisplay.Container[i].amount;
        //        inventoryCells[i].ImageToDisplay = inventoryToDisplay.Container[i].item.prefab;
        //        inventoryDisplay[i].GetComponentInChildren<TMP_Text>().text = inventoryCells[i].AmountToDisplay.ToString("n0");
        //        inventoryDisplay[i].GetComponent<Image>().sprite = inventoryCells[i].ImageToDisplay.GetComponent<Image>().sprite;
        //    }
        //    else 
        //    {
        //        break; //stop it from checking after hitting the first null because we remove from the end of the inventory list
        //    }
        //}
    }
    public Vector3 GetPosition(int index) //this will display it in a grid based on the other objects in the inventory
    {
        return new Vector3(XStart + (SpaceBetweenItemsXAxis * (index % ColumnCount)), YStart + (-SpaceBetweenItemsYAxis * (index / ColumnCount)), 0f);
    }
}
