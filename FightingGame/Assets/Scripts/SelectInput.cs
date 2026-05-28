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
    GlobalInformation g;

    float selectDelay;

    private void Update()
    {
        selectDelay -= Time.deltaTime;
    }

    void Start()
    {

        cs = FindFirstObjectByType<CharacterSelect>();
        g = FindAnyObjectByType<GlobalInformation>();

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
        if (selectDelay <= 0)
        {
            ready = !ready;
            selectDelay = .5f;

            if (ready)
            {
                cs.am.Play("Select");
            }
        }
    }
}
