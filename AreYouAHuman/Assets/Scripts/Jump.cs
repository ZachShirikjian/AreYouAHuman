using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float speed = 5;
    public float jumpVelocity;
    private Rigidbody2D rb2d;
    public float tapButtonGravity = 2f; //Gravity scale for when player taps button to jump
    public float holdButtonGravity = 2.5f; //Gravity scale for when player holds button to jump
    public bool canJump = true; //Bool telling us if we can jump or not, it's false if we're already jumping in the air 
    private Vector2 moveX; 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call Rigidbody2D's built in MovePosition() method
        //Move the Rigidbody of the player based on the Horizontal input, speed, and Time.deltaTime so player smoothly moves over time

       if(Input.GetKeyDown(KeyCode.Space))
        {
        rb2d.velocity = Vector2.up * jumpVelocity;
        canJump = false;
        if(rb2d.velocity.y < 0)
        {
        //Increase our gravity scale
        Debug.Log("falling");
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (holdButtonGravity - 1) * Time.deltaTime;
        }

        //         //If player lets go of space while still in the air, shorter jump
        else if(rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (tapButtonGravity - 1) * Time.deltaTime;
        }

        //If player is falling (velocity is negative) and is still holding space
        if(rb2d.velocity.y == 0)
        {
            canJump = true;
        }
        }
    }
}
