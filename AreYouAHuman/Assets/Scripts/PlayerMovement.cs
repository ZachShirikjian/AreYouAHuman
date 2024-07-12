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

    //Use public variables to test values for testing

    //REFERENCES//
    //The Player's Rigidbody2D, which handles all of its physics (movement, collision, etc.)
    //Visibility (Public/Private) Type Name 
    private Rigidbody2D rb2d;

    //The GroundCheck Transform attached as a Child to Zort to see if the Player is on the Ground or not.
    public Transform groundCheck;

    //The Layer attached to the Ground which players can move and jump on.
    public LayerMask groundLayer;

    //The SFX AudioSource where SFX play from.
    public AudioSource sfxSource;

    //The AudioManager script which holds all the SFX Audio to play during gameplay.
    public AudioManager audioManager;

    //Reset or initalize your variables at the start of every scene load!
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Searches all Components of Player for Rigidbody2D component, if it has one
    }
 
    // Update is called once per frame
    void Update()
    {
       movement = Input.GetAxisRaw("Horizontal");

       //If you're on the Ground layer and press SPACE, Jump!
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
       {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            sfxSource.PlayOneShot(audioManager.jump);
       }

       //If you let go of SPACE while you're in the air, fall down faster.
       //Tapping SPACE makes you fall faster than holding down SPACE. 
       if(Input.GetKeyUp(KeyCode.Space) && rb2d.velocity.y > 0f)
       {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
             // rb2d.velocity += Vector2.down * Physics2D.gravity.y * Time.deltaTime;
       }

       //Flip the direction Zort is facing in depending on moving Left or Right. 
       Flip();
    }

   //Sets Zort's Rigidbody velocity based on the Y velocity (for jumping), and the movement/speed (for Horizontal movement).
   void FixedUpdate()
    {
         rb2d.velocity = new Vector2(movement * speed, rb2d.velocity.y);
    }

    //Check if Zort is Grounded.
    //Returns TRUE if Zort is on the ground layer.
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //If Zort is facing to the right or left and are moving 
    //Flip them in the opposite direction.
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