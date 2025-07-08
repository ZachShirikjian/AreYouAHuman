using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This MUST be put outside of the class to be accessible to other scripts (ONLY applies to enums)

    //The specific position the item is placed on Zort's body (Head, Torso, Hand, Pants)
    //SerializeField allows this to be selectable in the Inspector.
    
    public enum Position
    {
        Head, 
        Torso, 
        Accessory, 
        Hand,
        Pants
    }

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    public Position itemPosition = new Position();
    //Put on each of the inventory items as they are prefabs

    //References their default sprite and sprite used for when they're picked up and put into the Inventory.

    //REFERENCES//
    private GameManager gm; 
    public Sprite defaultSprite;
    //public Sprite poseSprite; //Sprite used for the final pose

    //VARIABLES//
    public bool alreadyAdded =false; //Checks to see if the Inventory Item was already added to the Inventory or not.

    // Start is called before the first frame update
    void Start()
    {
        // icon.sprite = defaultSprite; 
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        // interactScript = GameObject.Find("Zort").GetComponent<PlayerInteract>();
    }
}
