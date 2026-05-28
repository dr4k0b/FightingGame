using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using static PlayerInformation;
public class PlayerMovement : MonoBehaviour
{
    PlayerInformation p;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    private float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p = GetComponent<PlayerInformation>();
        StartCoroutine(moveDelay());
    }

    IEnumerator moveDelay()
    {
        yield return new WaitForSeconds(2);
        p.canMove = true;
    }


    void FixedUpdate()
    {
        p.animator.SetFloat("Velocity", moveSpeed * (p.thisPlayer == Player.Player1 ? 1 : -1));
        if (p.canMove)
        {
            movePlayer();
        }
        else
        {
            rb.linearVelocityX = GetKnockback();
        }
        KnockbackBehaviour();
    }

    public void movePlayer()
    {

        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            if (Mathf.Abs(rb.linearVelocityX) < p.maxSpeed * Mathf.Abs(moveInput.x))
            {
                moveSpeed += p.acceleration * (moveInput.x / Mathf.Abs(moveInput.x));
            }
            else
            {
                moveSpeed = p.maxSpeed * moveInput.x;
            }
        }
        else if (Mathf.Abs(rb.linearVelocityX) > p.deacceleration)
        {
            moveSpeed -= p.deacceleration * (rb.linearVelocityX / Mathf.Abs(rb.linearVelocityX));
        }
        else
        {
            moveSpeed = 0;
        }

        rb.linearVelocityX = GetKnockback() + moveSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void KnockbackBehaviour()
    {
        if (p.currentKnockback > p.knockbackDeacceleration)
        {
            p.currentKnockback -= p.knockbackDeacceleration;
        }
        else
        {
            p.currentKnockback = 0;
        }
    }

    public float GetKnockback()
    {
        return p.currentKnockback * (p.thisPlayer == Player.Player1 ? -1 : 1);
    }
}
