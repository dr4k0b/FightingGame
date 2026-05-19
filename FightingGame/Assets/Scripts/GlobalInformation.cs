using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInformation;

public class GlobalInformation : MonoBehaviour
{

    public GameObject player1Character;
    public GameObject player2Character;

    public Gamepad p1Controller;
    public Gamepad p2Controller;

    public bool gameOver;

    public static GlobalInformation instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
