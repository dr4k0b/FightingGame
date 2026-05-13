using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerInformation;

public class PlayerHealth : MonoBehaviour
{
    PlayerInformation p;
    GlobalInformation g;

    void Start()
    {
        p = GetComponent<PlayerInformation>();
        g = FindFirstObjectByType<GlobalInformation>();
        p.health = p.maxHealth;
    }

    void Update()
    {
        if (p.health <= 0)
        {
            g.text.text = (p.thisPlayer == Player.Player1) ? "Player 2 Wins!" : "Player 1 Wins!";
            g.gameOver = true;
        }

        if (g.gameOver)
        {
        p.canMove = false;
        p.stunned = true;
        }
    }

    public void TakeDamage(float damage)
    {
        p.health -= damage;
        p.currentKnockback = p.knockback;
    }
}
