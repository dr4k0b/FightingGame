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
        Debug.Log("funkar");

        PlayerInformation hit;

        if (collision.GetComponent<PlayerInformation>())
            hit = collision.GetComponent<PlayerInformation>();
        else
            hit = collision.GetComponentInParent<PlayerInformation>();


        if (hit.thisPlayer == PlayerInformation.thisPlayer)
        {
            return;
        }

        if (!hit.GetComponent<PlayerInformation>().isParrying)
        {
            hit.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else
        {
            hit.GetComponent<PlayerBlocking>().Succesfull();
           
            if (isProjectile)
            {
                Destroy(gameObject.transform.parent.gameObject);
                return;
            }

            PlayerInformation.GetComponent<PlayerAttack>().Parried();
        }
    }
}

