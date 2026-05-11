using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerInformation p;
    public GameObject armAttack;
    public GameObject weapon;
   
    private bool attacking;
    void Start()
    {
        p = GetComponent<PlayerInformation>();  
    }
    void Update()
    {

    }

    public void Attack()
    {
        if (!attacking)
        { 
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay()
    {
        attacking = true;
        p.canMove = false;
        
        yield return new WaitForSeconds(p.windUp);

        armAttack.SetActive(true);
        weapon.SetActive(true);
       
        yield return new WaitForSeconds(p.Hurt);
       
        weapon.SetActive(false);
        
        yield return new WaitForSeconds(p.cooldown);
      
        armAttack.SetActive(false);
        attacking = false;
        p.canMove = true;
    }
}
