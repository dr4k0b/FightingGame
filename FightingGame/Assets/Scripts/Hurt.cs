using System.Collections;
using UnityEngine;
using static PlayerInformation;
public class Hurt : MonoBehaviour
{
    public PlayerInformation PlayerInformation;
    public float damage;
    public bool isProjectile;
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

        if (!hit.GetComponent<PlayerInformation>().isBlocking)
        {
            hit.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else 
        {
            if (isProjectile)
            {
                Destroy(gameObject.transform.parent.gameObject);
                return;
            }

            hit.GetComponent<PlayerBlocking>().Succesfull();
            PlayerInformation.GetComponent<PlayerAttack>().Parried();
        }
    }
}

