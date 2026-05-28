using System.Collections;
using UnityEngine;
using static PlayerInformation;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float distance;

    public float DeathTime;

    [HideInInspector]
    public PlayerInformation p;
    public Hurt hurt;

    public Animator ani;

    private Rigidbody2D rb;
    private Vector2 start;
    void Start()
    {
        start = transform.position;
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3((p.thisPlayer == Player.Player1 ? 1 : -1) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        rb.linearVelocityX = speed * (p.thisPlayer == Player.Player1 ? 1 : -1);
        if (Vector2.Distance(start, transform.position) >= distance)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyDelay()
    {
        speed = 0;
        if (ani != null)
            ani.SetTrigger("Death");
        yield return new WaitForSeconds(DeathTime);
        Debug.Log("funkar");
        Destroy(gameObject);
    }
}
