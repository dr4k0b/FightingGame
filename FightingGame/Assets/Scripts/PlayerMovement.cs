using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInformation p;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p = GetComponent<PlayerInformation>();
        p.canMove = true;   
    }
    void FixedUpdate()
    {
        if (p.canMove)
        {
            movePlayer();
        }
        else
        {
            rb.linearVelocityX = 0f;
        }
    }

    public void movePlayer()
    {
        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            if (Mathf.Abs(rb.linearVelocityX) < p.maxSpeed * Mathf.Abs(moveInput.x))
            {
                rb.linearVelocityX += p.acceleration * (moveInput.x / Mathf.Abs(moveInput.x)) ;
            }
            else
            {
                rb.linearVelocityX = p.maxSpeed * moveInput.x;
            }
        }
        else if (Mathf.Abs(rb.linearVelocityX) > p.deacceleration)
        {
            rb.linearVelocityX -= p.deacceleration * (rb.linearVelocityX / Mathf.Abs(rb.linearVelocityX));
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
