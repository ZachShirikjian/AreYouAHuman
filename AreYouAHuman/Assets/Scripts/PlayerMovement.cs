using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    public float speed = 5f; //factor of how fast/slow character moves
    private Rigidbody2D rb2d; //reference to RB, which holds player physics
    private SpriteRenderer sprite; //reference to player sprite to allow sprite switching
    private Vector2 moveX; //Vector which allows player to move in specific X direction

    //REFERENCES//
    // Start is called before the first frame update
    //Reset/initalize your variables at the start of every scene load!
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Searches all Components of Player for Rigidbody2D component, if it has one
        sprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Get the horizontal input from keyboard
        //Set the keyboard input as the X direction for moveX
        moveX = new Vector2(Input.GetAxis("Horizontal"), 0);
        //Call Rigidbody2D's built in MovePosition() method
        //Move the Rigidbody of the player based on the Horizontal input, speed, and Time.deltaTime so player smoothly moves over time
        rb2d.MovePosition(rb2d.position + moveX * speed * Time.deltaTime);

        if(moveX.x < 0)
        {
            Debug.Log("Moving Right");
            sprite.flipX = true;       
        }
        else if(moveX.x == 0)
        {
            Debug.Log("Set isMoving animation state to be false");
            Debug.Log("Reset to Idle animation");
        }
        else if(moveX.x > 0)
        {
            Debug.Log("Moving Right");
            sprite.flipX = false;
        }
    }
}
