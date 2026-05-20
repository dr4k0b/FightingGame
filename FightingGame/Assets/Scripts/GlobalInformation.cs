using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInformation;

public class GlobalInformation : MonoBehaviour
{

    public GameObject player1Character;
    public GameObject player2Character;

    public int p1Controller = -1;
    public int p2Controller = -1;

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


        foreach (var pad in Gamepad.all)
        {
            if (p1Controller == -1)
            {
                p1Controller = pad.deviceId;
            }
            else if (p2Controller == -1 && p2Controller != p1Controller)
            {
                p2Controller = pad.deviceId;
                break;
            }
        }
    }
}
