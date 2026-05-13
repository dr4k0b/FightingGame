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
