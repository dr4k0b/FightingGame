using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInformation;

public class SelectInput : MonoBehaviour
{
    [HideInInspector]
    public bool ready;

    [HideInInspector]
    public Vector2 choiceDir;

    [HideInInspector]
    public int choice;

    [HideInInspector]
    public bool switched;

    [HideInInspector]
    public Player thisPlayer;

    CharacterSelect cs;
    public Gamepad thisPad;


    int score;
    void Start()
    {
        thisPad = Gamepad.current;

        cs = FindFirstObjectByType<CharacterSelect>();

        if (cs.p1Choice == null)
        {
            cs.p1Choice = this;
            thisPlayer = Player.Player1;
        }
        else if (cs.p2Choice == null)
        {
            cs.p2Choice = this;
            thisPlayer = Player.Player2;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Switch(InputAction.CallbackContext context)
    {
        choiceDir = context.ReadValue<Vector2>();
    }
    public void Ready()
    {
        ready = !ready;
    }
}
