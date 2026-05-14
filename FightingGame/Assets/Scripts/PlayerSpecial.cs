using UnityEngine;
using System.Collections;

public class PlayerSpecial : MonoBehaviour
{
    PlayerInformation p;
    public GameObject armSpecial;

    [Header("Melee")]
    public GameObject weapon;
    public bool isMelee;
    [Header("Ranged")]
    public GameObject projectileStart;
    public GameObject projectile;
    public bool isRanged;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
    }

    private void Update()
    {
        p.animator.SetBool("Special", p.inSpecial);
        if (p.stunned)
        {
            if (weapon)
            {
                weapon.transform.localPosition = Vector3.down * 1000;
                weapon.SetActive(false);
            }

            if (armSpecial)
                armSpecial.SetActive(false);
        }
    }
    public void Special()
    {
        if (!p.attacking && !p.stunned && !p.inSpecial)
        {
            StartCoroutine(SpecialMelee());
            if (isRanged)
                StartCoroutine(SpecialRanged());
        }
    }

    IEnumerator SpecialMelee()
    {

        p.animator.SetTrigger("Next");
        p.inSpecial = true;
        p.canMove = false;

        yield return new WaitForSeconds(p.specialWindUp);

        armSpecial.SetActive(true);

        if (isMelee)
        {
            weapon.SetActive(true);
            weapon.transform.localPosition = Vector3.zero;
        }

        yield return new WaitForSeconds(p.specialHurt);

        if (isMelee)
        {
            weapon.transform.localPosition = Vector3.down * 1000;
            weapon.SetActive(false);
        }

        yield return new WaitForSeconds(p.specialCooldown);

        if (p.stunned) { yield break; }

        armSpecial.SetActive(false);
        p.inSpecial = false;
        p.canMove = true;
    }

    IEnumerator SpecialRanged()
    {
        yield return new WaitForSeconds(p.projectileDelay);

        if (p.stunned) { yield break; }

        GameObject projectileInfo;

        projectileInfo = Instantiate(projectile, projectileStart.transform.position, projectileStart.transform.rotation);
        projectileInfo.GetComponent<Projectile>().p = p;
        projectileInfo.GetComponentInChildren<Hurt>().PlayerInformation = p;
    }
}
