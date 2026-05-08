using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float deacceleration;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            rb.linearVelocityX += acceleration * (moveInput.x / Mathf.Abs(moveInput.x));
        }
        else if (Mathf.Abs(rb.linearVelocityX) > deacceleration)
        {
            rb.linearVelocityX -= deacceleration * (rb.linearVelocityX / Mathf.Abs(rb.linearVelocityX));
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
