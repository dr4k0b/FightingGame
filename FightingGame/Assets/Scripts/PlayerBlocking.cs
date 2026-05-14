using UnityEngine;
using System.Collections;
public class PlayerBlocking : MonoBehaviour
{
    PlayerInformation p;
    public GameObject Visual;
    private bool block;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
    }
    private void Update()
    {
        p.animator.SetBool("Block", block);
    }
    public void Block()
    {
        if (!block && !p.stunned && !p.attacking)
        {
            StartCoroutine(BlockDelay());
        }
    }
    public void Succesfull()
    {
        p.isBlocking = false;
        p.canMove = true;
        Visual.SetActive(false);
    }
    IEnumerator BlockDelay()
    {
        block = true;
        p.canMove = false;

        p.animator.SetTrigger("Next");
        yield return new WaitForSeconds(p.blockWindUp);

        p.isBlocking = true;
        Visual.SetActive(true);

        yield return new WaitForSeconds(p.blocking);

        p.isBlocking = false;
        Visual.SetActive(false);

        yield return new WaitForSeconds(p.blockCooldown);

        block = false;
        p.canMove = true;
    }
}
