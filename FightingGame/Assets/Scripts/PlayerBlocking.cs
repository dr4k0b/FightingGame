using UnityEngine;
using System.Collections;
public class PlayerBlocking : MonoBehaviour
{
    PlayerInformation p;
    public GameObject Visual;
    bool success;
    AudioManager am;
    void Start()
    {
        p = GetComponent<PlayerInformation>();
        am = GetComponent<AudioManager>();
    }
    private void Update()
    {
        p.animator.SetBool("Block", p.block);
    }
    public void Block()
    {
        if (p.canMove)
        {
            StartCoroutine(BlockDelay());
        }
    }
    public void Succesfull()
    {
        am.Play("Parry");
        success = true;
        p.isParrying = false;
        p.block = false;
        p.canMove = true;
        Visual.SetActive(false);
    }
    IEnumerator BlockDelay()
    {
        p.block = true;
        p.canMove = false;
        success = false;

        p.animator.SetTrigger("Next");
        yield return new WaitForSeconds(p.blockWindUp);

        p.isParrying = true;
        Visual.SetActive(true);

        yield return new WaitForSeconds(p.blocking);

        if (success)
        {
            yield break;
        }
        p.isParrying = false;
        Visual.SetActive(false);

        yield return new WaitForSeconds(p.blockCooldown);

        if (success)
        {
            yield break;
        }

        p.block = false;
        p.canMove = true;
    }
}
