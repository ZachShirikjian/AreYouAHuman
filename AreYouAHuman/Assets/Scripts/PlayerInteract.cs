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
    private GameManager gm; //Reference to GameManager scrpit

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && canInteract == true)
        {
            gm.playerInventory.Add(selectedObject);
            selectedObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Prop")
        {
            Debug.Log("CAN PICKUP PROP");
            gm.interactText.text = "[E] Pick up";
            canInteract = true;
            selectedObject = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        gm.interactText.text = "";
        canInteract = false;
        selectedObject = null;
    }
}
