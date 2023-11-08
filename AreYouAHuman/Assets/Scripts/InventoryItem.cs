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
    public Sprite defaultSprite;
    // public Sprite collectedSprite; 
    public Image icon; 
    // Start is called before the first frame update
    void Start()
    {
        icon.sprite = defaultSprite; 
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        // interactScript = GameObject.Find("Zort").GetComponent<PlayerInteract>();
    }
}
