using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{

    //Put on each of the inventory items as they are prefabs

    //References their default sprite and sprite used for when they're pickedup

    //REFERENCES//
    private GameManager gm; 
    private PlayerInteract interactScript; //reference to interact script 
    public Sprite defaultSprite;
    public Sprite collectedSprite; 
    public Image currentSprite; 
    // Start is called before the first frame update
    void Start()
    {
        currentSprite.sprite = defaultSprite; 
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        interactScript = GameObject.Find("Zort").GetComponent<PlayerInteract>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("CAN PICKUP PROP");
            gm.interactText.text = "[E] Pick up";
            interactScript.canInteract = true;
            interactScript.selectedObject = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        gm.interactText.text = "";
        interactScript.canInteract = false;
        interactScript.selectedObject = null;
    }
}
