using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerInformation;

public class PlayerHealth : MonoBehaviour
{
    PlayerInformation p;
    GlobalInformation g;
    GameManager gm;
    public SpriteRenderer renderer;

    public Material hurtmat;
    private Material normalmat;

    public AudioManager am;
    bool died;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
        g = FindFirstObjectByType<GlobalInformation>();
        gm = FindFirstObjectByType<GameManager>();
        am = GetComponent<AudioManager>();
        normalmat = renderer.material;
        p.health = p.maxHealth;
    }

    void Update()
    {
        p.animator.SetFloat("Health", p.health);

        if (p.health > 0)
            ((p.thisPlayer == Player.Player1) ? gm.p1HealthBar : gm.p2HealthBar).localScale = new Vector3(p.health / p.maxHealth, 1, 1);
        else
            ((p.thisPlayer == Player.Player1) ? gm.p1HealthBar : gm.p2HealthBar).localScale = new Vector3(0, 1, 1);

        if (p.health <= 0)
        {
            gm.winText.text = (p.thisPlayer == Player.Player1) ? "Player 2 Wins!" : "Player 1 Wins!";
            g.gameOver = true;
            p.health = -1;
        }

        if (g.gameOver && !died)
        {
            p.animator.SetTrigger("Next");
            am.Play("Death");
            died = true;
        }

        if (g.gameOver)
        {
            p.canMove = false;
            p.stunned = true;
        }
    }

    public void TakeDamage(float damage)
    {
        if (!g.gameOver)
        {
            p.health -= damage;
            p.currentKnockback = p.knockback;
            StartCoroutine(hurtVisual());
            am.Play("Hurt");
        }
    }

    IEnumerator hurtVisual()
    {
        renderer.material = hurtmat;
        yield return new WaitForSeconds(.1f);
        renderer.material = normalmat;
    }
}
