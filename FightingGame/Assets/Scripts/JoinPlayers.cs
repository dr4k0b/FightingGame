using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInformation;

public class JoinPlayers : MonoBehaviour
{
    GlobalInformation g;

    public Transform spawnpoint1;
    public Transform spawnpoint2;


    private bool player1joined;
    private bool player2joined;
    void Start()
    {
        player1joined = false;
        player2joined = false;
        Join();
    }
    void Update()
    {
    }

    private void Join()
    {

        if (player1joined && player2joined)
        {
            return;
        }
        g = FindFirstObjectByType<GlobalInformation>();

        if (!player1joined)
        {
            var p1 = PlayerInput.Instantiate(g.player1Character, controlScheme: "Controller", pairWithDevice: g.p1Controller);

            Debug.Log(g.p1Controller.deviceId);
            p1.transform.position = spawnpoint1.position;
            p1.GetComponent<PlayerInformation>().thisPlayer = Player.Player1;
            player1joined = true;
        }
        if (!player2joined)
        {
           if(g.p1Controller.deviceId == g.p2Controller.deviceId)
            {
                foreach(var pad in Gamepad.all)
                {
                    if(pad.deviceId != g.p1Controller.deviceId)
                    {
                        g.p2Controller = pad;
                        break;
                    }
                }
            }
            
            
            var p2 = PlayerInput.Instantiate(g.player2Character, controlScheme: "Controller", pairWithDevice: g.p2Controller);
            Debug.Log(g.p2Controller.deviceId);
            p2.transform.position = spawnpoint2.position;
            p2.GetComponent<PlayerInformation>().thisPlayer = Player.Player2;
            p2.transform.localScale = new Vector3(-1, 1, 1);
            player2joined = true;
        }

    }
}
