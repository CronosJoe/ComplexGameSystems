using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CellSlot
{
    public int AmountToDisplay; //these need to be public to update
    public GameObject ImageToDisplay;
    public CellSlot(int amountToDisplay, GameObject imageToDisplay)
    {
        AmountToDisplay = amountToDisplay;
        ImageToDisplay = imageToDisplay;
    }
}
