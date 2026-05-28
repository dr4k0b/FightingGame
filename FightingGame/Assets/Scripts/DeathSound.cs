using UnityEngine;

public class DeathSound : MonoBehaviour
{
    AudioManager am;
    GlobalInformation g;
    bool played;

    public Animator ani;
    void Start()
    {
        am = GetComponent<AudioManager>();
        g = FindFirstObjectByType<GlobalInformation>();
    }
    void Update()
    {
        if (g.gameOver && !played)
        {
            played = true;
            ani.SetTrigger("KO");
            am.Stop("Musik");
            am.Play("Death");
            am.Play("KO");
        }
    }
}
