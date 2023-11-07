using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    private float movement;
    private float speed = 5f;
    private float jumpPower = 30f;
    private bool IsFacingRight = true;

    //REFERENCES//
    private Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // public float acceleration = 0;
    // public float speed = 5f; //factor of how fast/slow character moves
    // private Rigidbody2D rb2d; //reference to RB, which holds player physics
    // private SpriteRenderer sprite; //reference to player sprite to allow sprite switching
    // private Vector2 moveX; //Vector which allows player to move in specific X direction
    // public bool canJump = true;
    // public bool shouldJump = false;
    // public float X_Accel = 90;
    // public float jumpVelocity;
    // public float tapButtonGravity = 2f; //Gravity scale for when player taps button to jump
    // public float holdButtonGravity = 2.5f; //Gravity scale for when player holds button to jump
    //REFERENCES//
    // Start is called before the first frame update
    //Reset/initalize your variables at the start of every scene load!
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Searches all Components of Player for Rigidbody2D component, if it has one
        // sprite = GetComponent<SpriteRenderer>(); 
    }
 
    // Update is called once per frame
    void Update()
    {
       movement = Input.GetAxisRaw("Horizontal");

       //Jump the player if space is pressed and if being grounded 
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
       {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
       }

       if(Input.GetKeyUp(KeyCode.Space) && rb2d.velocity.y > 0f)
       {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
                                // rb2d.velocity += Vector2.down * Physics2D.gravity.y * Time.deltaTime;
       }
       Flip();
    }

   void FixedUpdate()
    {
         rb2d.velocity = new Vector2(movement * speed, rb2d.velocity.y);
    }
    //Check if the player is grounded 
    //Return true if the player is on the ground layer
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //If the player is facing to the right or left and are moving 
    //Flip them in the opposite direction 
    void Flip()
    {
        if(IsFacingRight && movement < 0f || !IsFacingRight && movement > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}