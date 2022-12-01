using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TBInputField : MonoBehaviour
{
    [SerializeField] private GameObject Controller;
    [SerializeField] private TMP_InputField InputField;
    [SerializeField] private TextMeshProUGUI Text;
    public string CheckCanvasName()
    {
        switch (transform.parent.name)
        {
            case "Slot:1_MovesetCanvas":
                return "Slot:1_Canvas";
            case "Slot:2_MovesetCanvas":
                return "Slot:2_Canvas";
            case "Slot:3_MovesetCanvas":
                return "Slot:3_Canvas";
            case "Slot:4_MovesetCanvas":
                return "Slot:4_Canvas";
            case "Slot:5_MovesetCanvas":
                return "Slot:5_Canvas";
            case "Slot:6_MovesetCanvas":
                return "Slot:6_Canvas";

            case "Slot:1_StatCanvas":
                return "Slot:1_Canvas";
            case "Slot:2_StatCanvas":
                return "Slot:2_Canvas";
            case "Slot:3_StatCanvas":
                return "Slot:3_Canvas";
            case "Slot:4_StatCanvas":
                return "Slot:4_Canvas";
            case "Slot:5_StatCanvas":
                return "Slot:5_Canvas";
            case "Slot:6_StatCanvas":
                return "Slot:6_Canvas";
        }
        return null;
    }

    public string CheckCanvasType()
    {
        string Spliced = transform.parent.name.Substring(transform.parent.name.IndexOf("_") + 1);
        switch (Spliced)
        {
            case "Canvas":
                return "Canvas";

            case "MovesetCanvas":
                return "MovesetCanvas";

            case "StatCanvas":
                return "StatCanvas";
        }
        return null;
    }

    public void SendInput()
    {
        switch (transform.name)
        {
            case "Nicknamer":
                transform.parent.Find("PokemonController").GetComponent<PokemonController>().RecieveInput(Text.text, "Nickname");
                break;

            case "TeamNamer":
                Controller.GetComponent<TeamCanvasController>().SetTeamName(Text.text);
                break;

            case "Leveler":
                switch (CheckCanvasType())
                {
                    case "Canvas":
                        transform.parent.Find("PokemonController").GetComponent<PokemonController>().RecieveInput(Text.text, "Level");
                        break;

                    case "MovesetCanvas":
                        GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveInput(Text.text, "Level");
                        break;

                    case "StatCanvas":
                        GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveInput(Text.text, "Level");
                        break;
                }
                
                break;

            case "HPIVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "IV", "HP");
                break;

            case "AttackIVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "IV", "Attack");
                break;

            case "DefenseIVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "IV", "Defense");
                break;

            case "SpAtkIVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "IV", "SpAtk");
                break;

            case "SpDefIVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "IV", "SpDef");
                break;

            case "SpeedIVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "IV", "Speed");
                break;

            case "HPEVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "EV", "HP");
                break;

            case "AttackEVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "EV", "Attack");
                break;

            case "DefenseEVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "EV", "Defense");
                break;

            case "SpAtkEVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "EV", "SpAtk");
                break;

            case "SpDefEVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "EV", "SpDef");
                break;

            case "SpeedEVSetter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveIVEVINput(Text.text, "EV", "Speed");
                break;

            case "Move1Setter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveMoveInput(Text.text, 0);
                break;

            case "Move2Setter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveMoveInput(Text.text, 1);
                break;

            case "Move3Setter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveMoveInput(Text.text, 2);
                break;

            case "Move4Setter":
                GameObject.Find(CheckCanvasName()).transform.Find("PokemonController").GetComponent<PokemonController>().RecieveMoveInput(Text.text, 3);
                break;
        }
    }
}
