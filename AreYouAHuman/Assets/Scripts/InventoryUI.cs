using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script taken from INVENTORY CODE - Making an RPG in Unity (Ep 6) by Brackeys
//https://www.youtube.com/watch?v=YLhj7SfaxSE//
public class InventoryUI : MonoBehaviour
{
    //Updates the UI of our inventory to correctly displayed the item you got in the current slot 

    //REFERENCES//
    private GameManager gm;
    public GameObject slotList;
    public InventorySlot[] slots;
    // public InventorySlot[] InventorySlots = new InventorySlot[3];
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        slots = slotList.GetComponentsInChildren<InventorySlot>();
        for(int i = 0; i < slots.Length; i++)
        {
            Debug.Log("CLEARED SLOT");
            slots[i].ClearSlot();
        }
    }

    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < gm.playerInventory.Count)
            {
                Debug.Log("ADDED ITEM");
                // slots[i].AddItem(gm.inventoryItems[i]);
            }
            else 
            {
                slots[i].ClearSlot();
            }
            Debug.Log("CLEARED SLOT");
            slots[i].ClearSlot();
        }
        // InventorySlots = GetComponentsInChildren<InventorySlot>();
        // for(int i = 0; i < slots.Length; i++)
        // {
        //     if(i < gm.playerInventory.Count)
        //     {
        //         slots[i].AddItem(gm.playerInventory[i]);
        //     }
        //     else
        //     {
        //         slots[i].ClearSlot();
        //     }
        // }
    }
}
