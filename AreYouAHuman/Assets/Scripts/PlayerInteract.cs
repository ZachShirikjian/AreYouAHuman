using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //VARIABLES//
    public GameObject selectedObject = null; //object that's currently available to being selected
    public bool canInteract = false; //if player is nearby a Prop, this gets set to true, else this gets set to false
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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            gm.playerInventory.Add(selectedObject);
            Debug.Log("PICKEDUP PROP");
            inventoryUI.inventoryItems.Add(selectedObject.GetComponent<InventoryItem>());
            inventoryUI.UpdateUI();
            SwapSprite(selectedObject.GetComponent<InventoryItem>().itemPosition);
            //inventoryUI.UpdateUI(selectedObject.GetComponent<InventoryItem>());
            // selectedObject.GetComponent<InventoryItem>().Position;
            gm.itemsCollected++;
            selectedObject.SetActive(false);
        }
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
                break;
            case Position.Torso:
                Debug.Log("PROP ON TORSO");
                bodyParts[1].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[1].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                break;
            case Position.Hand:
                Debug.Log("PROP ON HAND");
                bodyParts[2].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                break;
            case Position.Pants:
                 Debug.Log("PROP ON PANTS");
                bodyParts[3].GetComponent<SpriteRenderer>().enabled = true; 
                bodyParts[3].GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<InventoryItem>().defaultSprite;
                break;
            default:
            break;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Prop")
        {
            if(gm.playerInventory.Count < gm.maxInventoryItems)
            {
                Debug.Log("CAN PICKUP PROP");
                gm.interactText.text = "Pick up";
                gm.interactPrompt.SetActive(true);
                canInteract = true;
                selectedObject = other.gameObject;
            }
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
