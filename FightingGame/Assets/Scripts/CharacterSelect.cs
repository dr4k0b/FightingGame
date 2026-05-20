using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlayerInformation;

public class CharacterSelect : MonoBehaviour
{

    [HideInInspector]
    public SelectInput p1Choice;
    [HideInInspector]
    public SelectInput p2Choice;

    public Image p1Preview;
    public Image p2Preview;

    public TMP_Text p1Text;
    public TMP_Text p2Text;

    public GameObject p1Ready;
    public GameObject p2Ready;

    public GameObject inputPrefab;
    GlobalInformation g;

    public List<GameObject> characters = new List<GameObject>();
    void Start()
    {
        g = FindFirstObjectByType<GlobalInformation>();

        join(g.p1Controller);
        join(g.p2Controller);
    }

    public SelectInput join(int id)
    {
        Gamepad pad = null;

        foreach (var pa in Gamepad.all)
        {
            if (pa.deviceId == id) pad = pa; break;
        }

        return PlayerInput.Instantiate(inputPrefab, controlScheme: "Controller", pairWithDevice: pad).GetComponent<SelectInput>();
    }
    void Update()
    {
        if (p1Choice)
        {
            int choice = ChooseCharacter(p1Choice);
            g.player1Character = characters[choice];

            p1Text.text = characters[choice].GetComponent<PlayerInformation>().characterName;
            p1Ready.SetActive(p1Choice.ready);
        }
        if (p2Choice)
        {
            int choice = ChooseCharacter(p2Choice);
            g.player2Character = characters[choice];


            p2Text.text = characters[choice].GetComponent<PlayerInformation>().characterName;
            p2Ready.SetActive(p2Choice.ready);
        }
        if ((p1Choice && p2Choice) && p1Choice.ready && p2Choice.ready)
        {
            SceneManager.LoadScene("Game");
        }



    }

    public int ChooseCharacter(SelectInput choice)
    {
        if (Mathf.Abs(choice.choiceDir.x) > 0.1f && !choice.ready)
        {
            if (choice.switched == false)
            {
                choice.choice += (int)(Mathf.Abs(choice.choiceDir.x) / choice.choiceDir.x);

                if (choice.choice < 0) choice.choice = characters.Count - 1;
                if (choice.choice > characters.Count - 1) choice.choice = 0;

                choice.switched = true;
            }
        }
        else
        {
            choice.switched = false;
        }

        if (choice.thisPlayer == Player.Player1 && g.player1Character)
        {
            p1Preview.sprite = g.player1Character.GetComponentInChildren<SpriteRenderer>().sprite;
        }

        if (choice.thisPlayer == Player.Player2 && g.player2Character)
        {
            p2Preview.sprite = g.player2Character.GetComponentInChildren<SpriteRenderer>().sprite;
        }

        return choice.choice;
    }
}
