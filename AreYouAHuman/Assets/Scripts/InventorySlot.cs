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
    public InventoryUI theUI; //reference to the UI for the Inventory
    public GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void AddItem(InventoryItem newItem)
    {
        item = newItem;
        Debug.Log(newItem.ToString());
        icon.sprite = item.defaultSprite;
        icon.enabled = true;
    }

    //Clears inventory slot UI when an Item is removed in the Inventory script 
    //If the timer's stopped, you can't drop any items.
    public void ClearSlot()
    {
        if(gm.timerRunning == true)
        {
            theUI.RemoveItem(item);
            item = null;
            icon.sprite = null;
            icon.enabled = false;
            Debug.Log("CLEARED ITEM");
        }
        else if(gm.timerRunning == false)
        {
            Debug.Log("TIME'S UP, SORRY");
        }

    }
}
