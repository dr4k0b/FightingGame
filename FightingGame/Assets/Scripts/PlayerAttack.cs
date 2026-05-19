using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    PlayerInformation p;
    public GameObject armAttack;
    public GameObject weapon;
    public GameObject StunnedVisual;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
    }
    private void Update()
    {
        p.animator.SetBool("Attack", p.attacking);

    }
    public void Attack()
    {
        if (!p.attacking && !p.stunned && !p.inSpecial && !p.isBlocking)
        {
            StartCoroutine(AttackDelay());
        }
    }


    public void Parried()
    {
        StartCoroutine(ParriedDelay());
    }

    IEnumerator ParriedDelay()
    {
        p.stunned = true;
        p.currentKnockback = p.knockback;
        weapon.transform.localPosition = Vector3.down * 1000;

        StunnedVisual.SetActive(true);
        weapon.SetActive(false);
        armAttack.SetActive(false);

        p.attacking = false;
        p.inSpecial = false;
        p.canMove = false;

        yield return new WaitForSeconds(p.stunnedTime);

        StunnedVisual.SetActive(false);

        p.canMove = true;
        p.stunned = false;
    }
    IEnumerator AttackDelay()
    {
        p.attacking = true;
        p.canMove = false;

        p.animator.SetTrigger("Next");

        yield return new WaitForSeconds(p.windUp);

        armAttack.SetActive(true);
        weapon.SetActive(true);
        weapon.transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(p.Hurt);

        weapon.transform.localPosition = Vector3.down * 1000;
        weapon.SetActive(false);

        yield return new WaitForSeconds(p.cooldown);

        if (p.stunned) { yield break; }

        armAttack.SetActive(false);
        p.attacking = false;
        p.canMove = true;
    }
}
