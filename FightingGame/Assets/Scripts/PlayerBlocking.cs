using UnityEngine;
using System.Collections;
public class PlayerBlocking : MonoBehaviour
{
    PlayerInformation p;
    public GameObject Visual;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
    }
    private void Update()
    {
        p.animator.SetBool("Block", p.block);
    }
    public void Block()
    {
        if (!p.block && !p.stunned && !p.attacking && !p.inSpecial)
        {
            StartCoroutine(BlockDelay());
        }
    }
    public void Succesfull()
    {
        p.isParrying = false;
        p.canMove = true;
        Visual.SetActive(false);
    }
    IEnumerator BlockDelay()
    {
        p.block = true;
        p.canMove = false;

        p.animator.SetTrigger("Next");
        yield return new WaitForSeconds(p.blockWindUp);

        p.isParrying = true;
        Visual.SetActive(true);

        yield return new WaitForSeconds(p.blocking);

        p.isParrying = false;
        Visual.SetActive(false);

        yield return new WaitForSeconds(p.blockCooldown);

        p.block = false;
        p.canMove = true;
    }
}
