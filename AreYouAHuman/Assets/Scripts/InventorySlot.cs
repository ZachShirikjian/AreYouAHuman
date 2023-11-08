using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script taken from INVENTORY CODE - Making an RPG in Unity (Ep 6) by Brackeys
//https://www.youtube.com/watch?v=YLhj7SfaxSE//
public class InventorySlot : MonoBehaviour
{
    //Updates the UI of our inventory to correctly displayed the item you got in the current slot 

    //REFERENCES//
    public Image icon; //reference to a UI icon of inventory slot 

    InventoryItem item; //reference to an Item from our Item class 

    public void AddItem(InventoryItem newItem)
    {
        item = newItem;

        icon.sprite = item.defaultSprite;
        icon.enabled = true;
    }

    //Clears inventory slot UI when an Item is removed in the Inventory script 
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
