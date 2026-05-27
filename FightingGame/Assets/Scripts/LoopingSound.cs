using UnityEngine;

public class LoopingSound : MonoBehaviour
{
    AudioManager am;

    public string[] Name;
    void Start()
    {
        am = GetComponent<AudioManager>();

        foreach (var name in Name)
        {

            am.Play(name);

        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
