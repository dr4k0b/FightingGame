using System.Collections;
using UnityEngine;
using static PlayerInformation;
public class Hurt : MonoBehaviour
{
    public PlayerInformation PlayerInformation;
    public float damage;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        PlayerInformation hit;

        if (collision.GetComponent<PlayerInformation>())
            hit = collision.GetComponent<PlayerInformation>();
        else
            hit = collision.GetComponentInParent<PlayerInformation>();


        if (hit.thisPlayer == PlayerInformation.thisPlayer)
        {
            return;
        }

        if (!collision.GetComponent<PlayerInformation>().isBlocking)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else
        {
            collision.GetComponent<PlayerBlocking>().Succesfull();
            PlayerInformation.GetComponent<PlayerAttack>().Parried();
        }
    }
}

