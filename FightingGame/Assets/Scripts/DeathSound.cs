using UnityEngine;

public class DeathSound : MonoBehaviour
{
    AudioManager am;
    GlobalInformation g;
    bool played;
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
            am.Stop("Musik");
            am.Play("Death");
            am.Play("KO");
        }
    }
}
