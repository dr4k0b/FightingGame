using UnityEngine;
using static PlayerInformation;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float distance;

    [HideInInspector]
    public PlayerInformation p;
    public Hurt hurt;

    private Rigidbody2D rb;
    private Vector2 start;
    void Start()
    {
        start = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocityX = speed * (p.thisPlayer == Player.Player1 ? 1 : -1);

        if (Vector2.Distance(start, transform.position) >= distance)
        {
            Destroy(gameObject);
        }
    }
}
