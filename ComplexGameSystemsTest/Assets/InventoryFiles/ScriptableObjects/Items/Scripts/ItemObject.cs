using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType //I will be providing base types of items you can expand upon this list for your game
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type; //storing this items type
    [TextArea(15, 20)]
    public string description; //storing the items description
    
}
