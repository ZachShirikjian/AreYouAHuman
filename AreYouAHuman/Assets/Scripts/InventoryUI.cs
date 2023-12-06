using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script partially taken from INVENTORY CODE - Making an RPG in Unity (Ep 6) by Brackeys
//https://www.youtube.com/watch?v=YLhj7SfaxSE//
public class InventoryUI : MonoBehaviour
{
    //Updates the UI of our inventory to correctly displayed the item you got in the current slot 

    //REFERENCES//
    private GameObject player;
    private PlayerInteract playerInteractScript;
    private GameManager gm;
    public GameObject slotList;
    public InventorySlot[] slots;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public AudioSource sfxSource;
    public AudioManager audioManager;
    //At the start of the level, clear all of the Inventory Slots
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
        playerInteractScript = player.GetComponent<PlayerInteract>();
        slots = slotList.GetComponentsInChildren<InventorySlot>();
        for(int i = 0; i < slots.Length; i++)
        {
            Debug.Log("CLEARED ALL SLOTS");
            slots[i].ClearSlot();
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < gm.playerInventory.Count; i++)
        {
            slots[i].AddItem(inventoryItems[i]);
            inventoryItems[i].alreadyAdded = true;
            sfxSource.PlayOneShot(audioManager.collectItem);
        }
        if(gm.playerInventory.Count == gm.maxInventoryItems)
        {
            gm.submitButton.SetActive(true);
        }
        // if(currentSlot < 3)
        // {
        //     Debug.Log("WORKS");
        //     inventoryItems.Add(item);
        //     slots[currentSlot].AddItem(item);
        //     currentSlot++;
        // }

        // if(item.alreadyAdded == false)
        // {
        //     for(int i = 0; i < 3; i++)
        //     {
        //         if((i < gm.playerInventory.Count && i >= 0)&& inventoryItems[i] == null)
        //         {
        //             inventoryItems.Add(item);
        //             slots[i].AddItem(item);
        //             // inventoryItems[i].alreadyAdded = true;
        //         }
    
        //             // if(inventoryItems[i].alreadyAdded == false)
        //             // {
        //             //     Debug.Log("CAN ADD ITEM");
        //             //     slots[i].AddItem(item);
        //             //     inventoryItems[i].alreadyAdded = true;
        //             // }
        //         }
        //         item.alreadyAdded = true;
        // }

        }

    //Removes an item from the inventory when the button is clicked.
    public void RemoveItem(InventoryItem item)
    {
        // slots[].ClearSlot();
        // inventoryItems[i].alreadyAdded = false;
        inventoryItems.Remove(item);
        sfxSource.PlayOneShot(audioManager.dropItem);
        if(gm.playerInventory.Count > 0)
        {
            Debug.Log("REMOVAL SUCCESSFUL");
            item.gameObject.SetActive(true);
            item.gameObject.transform.position = player.transform.position;
            switch(item.itemPosition)
            {
                case Position.Head:
                    playerInteractScript.bodyParts[0].GetComponent<SpriteRenderer>().enabled = true; 
                     playerInteractScript.bodyParts[0].GetComponent<SpriteRenderer>().sprite = null;
                     playerInteractScript.headAdded = false;
                break;
                case Position.Torso:
                     playerInteractScript.bodyParts[1].GetComponent<SpriteRenderer>().enabled = true; 
                     playerInteractScript.bodyParts[1].GetComponent<SpriteRenderer>().sprite = null;
                     playerInteractScript.torsoAdded = false;
                break;
                case Position.Hand:
                     playerInteractScript.bodyParts[2].GetComponent<SpriteRenderer>().enabled = true; 
                     playerInteractScript.bodyParts[2].GetComponent<SpriteRenderer>().sprite = null;
                     playerInteractScript.handAdded = false;
                break;
                case Position.Pants:
                     playerInteractScript.bodyParts[3].GetComponent<SpriteRenderer>().enabled = true; 
                     playerInteractScript.bodyParts[3].GetComponent<SpriteRenderer>().sprite = null;
                     playerInteractScript.pantsAdded = false;   
                break;
                default:
                break;
            }
            // Destroy(item.gameObject);
            gm.playerInventory.Remove(item.gameObject);
            gm.itemsCollected--;
        }
    }
}
