using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public int inventorySize; //this will cap the maximum amount of inventory slots there are for unique items
   
    //adding items
    public void AddItem(ItemObject _item, int _amount) 
    {
        for (int i = 0; i < Container.Count; i++) 
        {
            if(Container[i].item == _item) 
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        AddNewSlot(_item, _amount);
    }
    //Adding a new inventory slot to the list
    private void AddNewSlot(ItemObject _item, int _amount) 
    {
        Container.Add(new InventorySlot(_item, _amount));
    }
    //removing items
    public void RemoveAtIndex(int index)
    {
        if(!(Container.Count>=index) && !(index < 0))
        {
            Container.RemoveAt(index);
        }
    }
    //Clearing the inventory to completely empty it
    public void ClearInventory() 
    {
        Container.Clear();
    }
    //Sorting/swapping functionality
    public void Swap(int swappingIndex, int swappedIndex) //the first parameter will be swapped into the position of the second and visa versa
    {
        InventorySlot tmpInventorySlot = Container[swappedIndex]; //save the one that will be overrode
        Container[swappedIndex] = Container[swappingIndex]; //replace the one we saved in a local
        Container[swappingIndex] = tmpInventorySlot; //finish the swap
    }
    public void SortByType() 
    {
       Container.Sort(delegate (InventorySlot a, InventorySlot b)
        {
            return a.item.type.CompareTo(b.item.type);
        });
    } public void SortByCost() 
    {
       Container.Sort(delegate (InventorySlot a, InventorySlot b)
        {
            return a.item.cost.CompareTo(b.item.cost);
        });
    }
}
