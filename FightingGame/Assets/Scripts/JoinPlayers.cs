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
            Gamepad pad = null;
            foreach (var pa in Gamepad.all)
            {
                if (pa.deviceId == g.p1Controller) pad = pa; break;
            }

            Debug.Log(g.p1Controller);

            var p1 = PlayerInput.Instantiate(g.player1Character, controlScheme: "Controller", pairWithDevice: pad);

            p1.transform.position = spawnpoint1.position;
            p1.GetComponent<PlayerInformation>().thisPlayer = Player.Player1;
            player1joined = true;
        }
        if (!player2joined)
        {
            Gamepad pad = null;
            foreach (var p in Gamepad.all)
            {
                if (p.deviceId == g.p2Controller) pad = p; break;
            }

            Debug.Log(g.p2Controller);

            var p2 = PlayerInput.Instantiate(g.player2Character, controlScheme: "Controller", pairWithDevice: pad);
            p2.transform.position = spawnpoint2.position;
            p2.GetComponent<PlayerInformation>().thisPlayer = Player.Player2;
            p2.transform.localScale = new Vector3(-1, 1, 1);
            player2joined = true;
        }

    }
}
