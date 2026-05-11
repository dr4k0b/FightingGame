using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    PlayerInformation p;
    Rigidbody2D rb;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
        rb = GetComponent<Rigidbody2D>();
        p.health = p.maxHealth;
    }

    void Update()
    {
        if (p.health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(float damage)
    {
        p.health -= damage;
        rb.linearVelocityX = p.knockback;
    }
}
