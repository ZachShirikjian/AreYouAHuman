using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script partially taken from INVENTORY CODE - Making an RPG in Unity (Ep 6) by Brackeys
//https://www.youtube.com/watch?v=YLhj7SfaxSE//
public class InventoryUI : MonoBehaviour
{
    //Updates the UI of our inventory to correctly displayed the item you got in the current slot 

    //REFERENCES//
    private GameManager gm;
    public GameObject slotList;
    public InventorySlot[] slots;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    // public InventorySlot[] InventorySlots = new InventorySlot[3];

    //At the start of the level, clear all of the Inventory Slots
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        slots = slotList.GetComponentsInChildren<InventorySlot>();
        for(int i = 0; i < slots.Length; i++)
        {
            Debug.Log("CLEARED ALL SLOTS");
            slots[i].ClearSlot();
        }
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < gm.playerInventory.Count)
            {
                // if(inventoryItems[i].alreadyAdded == true)
                // {
                //     Debug.Log("CAN'T ADD RIP");
                // }
                if(inventoryItems[i].alreadyAdded == false)
                {
                    Debug.Log("ADDED ITEM");
                    slots[i].AddItem(inventoryItems[i]);
                    inventoryItems[i].alreadyAdded = true;
                }
                // slots[i].AddItem(gm.inventoryItems[i]);
            }
            // else 
            // {
            //      slots[i].ClearSlot();
            // }

        }
    }
}
