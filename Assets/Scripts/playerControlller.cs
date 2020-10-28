using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlller : MonoBehaviour
{
    //Public vars
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos; //Position, rotation and scale of an object.
    [SerializeField] private LayerMask whatIsGround;

    // Private vars
    private Rigidbody2D rBody;
    private bool isGrounded = false; //make sure i am not touching the ground initially
    private Animator anim;
    private bool isFacingRight;
    private bool isDucking =  false;
    private float crouch;

    void Start()
    {
        // Catching the rbody
        rBody = GetComponent<Rigidbody2D>();
        //Catching the animator
        anim = GetComponent<Animator>();
        isFacingRight = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Return the value of the x axis
        float horizontal = Input.GetAxis("Horizontal");
        crouch = Input.GetAxisRaw("Crouch");
        isGrounded = GroundCheck();

        //Jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        //if (isGrounded && Input.GetButtonDown("Crouch"))
        //{
        //    anim.SetBool("isDucking", true);
        //}
        //else if(Input.GetKeyUp("down") || Input.GetKeyUp("s"))
        //{
        //    anim.SetBool("isDucking", false);
        //}

        

        // Accesing the velocity property of the rigidBody and defining in x , y
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y); // feeding the player's y velocity into itself

        // Crouching code
        CrouchFunction();

        if (rBody.velocity.x > 0)
        {
            anim.SetBool("isDucking", false);
        }
        else if (rBody.velocity.x < 0)
        {
            anim.SetBool("isDucking", false);
        }

        //check if the sprite needs to be flipped
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }

        // communicate with the animator, Setting the float to speed on x and y
        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("ySpeed", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    void CrouchFunction()
    {
        if ((crouch!=0) && isGrounded == true)
        {
            anim.SetBool("isDucking", true);
        }
        else
        {
            anim.SetBool("isDucking", false);
        }
    }
}
