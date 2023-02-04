using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float movementSpeed, jumpForce;
    BoxCollider2D boxCollider2D;        
    
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();       
    }
    private void FixedUpdate()
    {
        Run(movementSpeed);
        Jump(jumpForce);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();       
    }
    void OnJump(InputValue value)
    {       
        if(value.isPressed && IsGrounded())
        {
            rb.velocity += new Vector2(0f, jumpForce);
        }
       
    }
    private void Run(float runSpeed)
    {
        runSpeed = movementSpeed;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed , rb.velocity.y);
        rb.velocity = playerVelocity;
    }
    private void Jump(float jumpForce)
    {
        jumpForce = this.jumpForce;
        Vector2 playerVelocity = new Vector2(rb.velocity.x, moveInput.y * jumpForce);
    }
    private bool IsGrounded()
    {
        RaycastHit2D hitInfo;
        return true;
    }
}
