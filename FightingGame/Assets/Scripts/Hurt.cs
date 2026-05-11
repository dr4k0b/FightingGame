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
        if (collision.tag == "Player")
        {
            PlayerInformation hit;

            if (collision.GetComponent<PlayerInformation>())
                hit = collision.GetComponent<PlayerInformation>();
            else
                hit = collision.GetComponentInParent<PlayerInformation>();


            if (hit.thisPlayer != PlayerInformation.thisPlayer)
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
}

