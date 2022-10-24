using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    /* Update is called once per frame
     * Should be used for recieving inputs*/
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //returns a value of +/-1 or 0 depending on direction moved

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); //when jump button is pressed and player is grounded, player jumps by having y-value set to jumpingPower
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //allows user to jump higher or lower depending duration of button press
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

   
    /*Updated at a fixed rate and therefore should be used for anything that the inputs
     * within Update() call for*/
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // creates an invisible circle at the player's feet, allows player to jump when it collides with the ground layer
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
