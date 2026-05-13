using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static PlayerInformation;

public class CharacterSelect : MonoBehaviour
{

    //  [HideInInspector]
    public SelectInput p1Choice;
    //  [HideInInspector]
    public SelectInput p2Choice;

    public TMP_Text p1Text;
    public TMP_Text p2Text;

    GlobalInformation g;

    public List<GameObject> characters = new List<GameObject>();
    void Start()
    {
        g = FindFirstObjectByType<GlobalInformation>();
    }
    void Update()
    {
        if (p1Choice)
        {
            int choice = ChooseCharacter(p1Choice);
            g.player1Character = characters[choice];
            g.p1Controller = p1Choice.thisPad;
            p1Text.text = characters[choice].GetComponent<PlayerInformation>().characterName;
        }
        if (p2Choice)
        {
            int choice = ChooseCharacter(p2Choice);
            g.player2Character = characters[choice];
            g.p2Controller = p2Choice.thisPad;
            p2Text.text = characters[choice].GetComponent<PlayerInformation>().characterName;
        }
        if ((p1Choice && p2Choice) && p1Choice.ready && p2Choice.ready)
        {
            SceneManager.LoadScene("Game");
        }



    }

    public int ChooseCharacter(SelectInput choice)
    {
        if (Mathf.Abs(choice.choiceDir.x) > 0.1f)
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
        return choice.choice;
    }
}
