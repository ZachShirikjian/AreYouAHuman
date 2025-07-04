using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //VARIABLES//
    public GameObject selectedObject = null; //object that's currently available to being selected
    public bool canInteract = false; //if player is nearby a Prop, this gets set to true, else this gets set to false
    
    //List of BOOLS checking if a Prop is already on a Body Part for Zort 
    public bool headAdded = false;
    public bool torsoAdded = false;
    public bool handAdded = false;
    public bool pantsAdded = false;

    //REFERENCES//
    public BoxCollider2D interactCollider; //Reference to Player's Interact Collider (separate GameObject)
    private GameManager gm; //Reference to GameManager script
    public InventoryUI inventoryUI; //Reference to inventoryUI script 

    //LIST OF ALL THE BODY PARTS PROPS CAN BE PUT ON 
    public GameObject[] bodyParts = new GameObject[4]; 


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        headAdded = false;
        torsoAdded = false;
        handAdded = false;
        pantsAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {

            //Adds the Item players pickup from the ground.
            //If there is currently an object on the body part, drop that item and replace it with the new one.
            AddItem();
        }
    }

    //Adds item to Player's Body based on the body part assigned to the InventoryItem
    public void AddItem()
    {
            gm.playerInventory.Add(selectedObject);
            Debug.Log("PICKEDUP PROP");
            inventoryUI.inventoryItems.Add(selectedObject.GetComponent<InventoryItem>());
            inventoryUI.UpdateUI();
            //inventoryUI.UpdateUI(selectedObject.GetComponent<InventoryItem>());
            // selectedObject.GetComponent<InventoryItem>().Position;
            SwapSprite(selectedObject.GetComponent<InventoryItem>().itemPosition);
            gm.itemsCollected++;
            selectedObject.SetActive(false);
    }
    //Puts on the Prop the player picked up to the correctly assigned part of Zort's body.//
    //Set the Position of the InventoryItem in the itemPosition dropdown menu in the Inspector.//
    public void SwapSprite(Position pos)
    {
        switch(pos)
        {
            case Position.Head:
                Debug.Log("PROP ON HEAD");
                bodyParts[0].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[0].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                headAdded = true;
                break;
            case Position.Torso:
                Debug.Log("PROP ON TORSO");
                bodyParts[1].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[1].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                torsoAdded = true;
                break;
            case Position.Accessory:
                Debug.Log("ACCESSORY COLLECTED");
                bodyParts[2].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                handAdded = true;
                break;
            case Position.Pants:
                 Debug.Log("PROP ON PANTS");
                bodyParts[3].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[3].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                pantsAdded = true;
                break;
            default:
            break;
        }
    }


    //When the Player (Zort) is inside of the Trigger Collider of a Prop GameObject,
    //If the Player has room in their Inventory, 
    //Enable the InteractPrompt UI


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Prop")
        {
            //If there is enough space in a player's inventory,
            //Allow the player to pickup an item.
            if(gm.playerInventory.Count < gm.maxInventoryItems)
            {
                    selectedObject = other.gameObject;

                //If the Player doesn't have room in their Inventory
                //Prompt the User to remove an item from that slot in the UI.

                //Check the Position of where an Item goes on the Player's body.
                //If an item was already added to that space
                if (selectedObject.GetComponent<InventoryItem>().itemPosition == Position.Head && headAdded == true)
                {
                    Debug.Log("HEAD ALREADY TAKEN, PLEASE DROP");
                    gm.interactText.text = selectedObject.GetComponent<InventoryItem>().itemPosition.ToString() + " already taken. Please drop.";
                    canInteract = false;
                }

                else if (selectedObject.GetComponent<InventoryItem>().itemPosition == Position.Accessory && handAdded == true)
                {
                    Debug.Log("ACCESSORY ALREADY TAKEN, PLEASE DROP");
                    gm.interactText.text = selectedObject.GetComponent<InventoryItem>().itemPosition.ToString() + " already taken. Please drop.";
                    canInteract = false;
                }

                else if (selectedObject.GetComponent<InventoryItem>().itemPosition == Position.Torso && torsoAdded == true)
                {
                    Debug.Log("TORSO ALREADY TAKEN, PLEASE DROP");
                    gm.interactText.text = selectedObject.GetComponent<InventoryItem>().itemPosition.ToString() + " already taken. Please drop.";
                    canInteract = false;
                }

                else if (selectedObject.GetComponent<InventoryItem>().itemPosition == Position.Pants && pantsAdded == true)
                {
                    Debug.Log("PANTS ALREADY TAKEN, PLEASE DROP");
                    gm.interactText.text = selectedObject.GetComponent<InventoryItem>().itemPosition.ToString() + " already taken. Please drop.";
                    canInteract = false;
                }
                else
                {
                        Debug.Log("CAN PICKUP PROP");
                        gm.interactText.text = "Collect";
                        gm.interactPrompt.SetActive(true);
                        canInteract = true;
                }
            }

            //If the Player's current Inventory is greater or equal to the Maximum amount of items in your Inventory
            //Indicate that the Inventory is Full
            else if(gm.playerInventory.Count >= gm.maxInventoryItems)
            {
                Debug.Log("CAN'T PICKUP PROP");
                gm.interactText.text = "Inventory is Full";
            }

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        gm.interactText.text = "";
        gm.interactPrompt.SetActive(false);
        canInteract = false;
        selectedObject = null;
    }

}
