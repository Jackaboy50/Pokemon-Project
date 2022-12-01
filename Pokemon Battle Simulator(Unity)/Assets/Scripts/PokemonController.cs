using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using TMPro;
using UnityEngine.UI;

public class PokemonController : MonoBehaviour
{
    private int Slot;
    private Canvas PokemonCanvas;
    private Pokemon P;
    private TeamCanvasController TeamController;
    private Functions fn = new Functions();

    private bool set = false;
    private bool Icons = false;
    private bool SetPokemonImage = false;

    [Header("Value Changers")]
    [SerializeField] private TMP_InputField Nicknamer;
    [SerializeField] private TextMeshProUGUI Name;

    [Header("Images")]
    [SerializeField] private RawImage PokemonImage;
    [SerializeField] private GameObject TypeIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        PokemonCanvas = transform.GetComponentInParent<Canvas>();
        fn.GenTypes();
    }

    // Update is called once per frame
    void Update()
    {
        if (Icons == false)
        {
            if(P != null)
            {
                if (P.ReturnType2() != null)
                {
                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(P.ReturnType1().ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-342, 231);
                    transform.parent.Find("TypeIcon(Clone)").name = "LeftIcon";

                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(P.ReturnType2().ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-148, 231);
                    transform.parent.Find("TypeIcon(Clone)").name = "RightIcon";
                    Icons = true;
                }
                else
                {
                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(P.ReturnType1().ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-243, 231);
                    transform.parent.Find("TypeIcon(Clone)").name = "MidIcon";
                    Icons = true;
                }
            }
        }
    }

    public void SetController(TeamCanvasController T)
    {
        TeamController = T;
    }

    public void SetImage(Texture s)
    {
        PokemonImage.texture = s;
        PokemonImage.enabled = true;
    }

    public void SetSlotNum(int s)
    {
        Slot = s;
    }

    public void ToggleShiny()
    {
        P.Shiny = !P.Shiny;
        TeamController.UpdatePokemon(P, Slot);
    }

    public void SetPokemon(Pokemon p)
    {
        if(set == false)
        {
            P = p;
            set = true;
        }
    }

    public int GetSlotNum()
    {
        return Slot;
    }

    public void RecieveInput(string Input , string Case)
    {
        switch (Case)
        {
            case "Nickname":
                P.Nickname = Input;
                break;

            case "Level":
                Input = Input.Remove(Input.Length - 1);
                P.Level = int.Parse(Input);
                break;
        }
        TeamController.UpdatePokemon(P, Slot);
    }

    public void RecieveMoveInput(string Input, int Case)
    {
        Input = Input.Remove(Input.Length - 1);
        Move M = WebScraper.GetMove(Input);
        P.Moveset[Case] = M;
        TeamController.UpdatePokemon(P, Slot);
        GameObject.Find(CheckCanvasName()).transform.Find("MovesetController").GetComponent<MovesetControllerScript>().CreateIcon(Case, M.ReturnType(), M.ReturnPP());
    }

    public string CheckCanvasName()
    {
        switch (transform.parent.name)
        {
            case "Slot:1_Canvas":
                return "Slot:1_MovesetCanvas";
            case "Slot:2_Canvas":
                return "Slot:2_MovesetCanvas";
            case "Slot:3_Canvas":
                return "Slot:2_MovesetCanvas";
            case "Slot:4_Canvas":
                return "Slot:4_MovesetCanvas";
            case "Slot:5_Canvas":
                return "Slot:5_MovesetCanvas";
            case "Slot:6_Canvas":
                return "Slot:6_MovesetCanvas";
        }
        return null;
    }

    public void RecieveIVEVINput(string Input, string V, string Case)
    {
        Input = Input.Remove(Input.Length - 1);
        switch (V)
        {
            case "EV":
                switch (Case)
                {
                    case "HP":
                        P.UpdateEVs(0,int.Parse(Input));
                        break;

                    case "Attack":
                        P.UpdateEVs(1, int.Parse(Input));
                        break;

                    case "Defense":
                        P.UpdateEVs(2, int.Parse(Input));
                        break;

                    case "SpAtk":
                        P.UpdateEVs(3, int.Parse(Input));
                        break;

                    case "SpDef":
                        P.UpdateEVs(4, int.Parse(Input));
                        break;

                    case "Speed":
                        P.UpdateEVs(5, int.Parse(Input));
                        break;
                }
                break;

            case "IV":
                switch (Case)
                {
                    case "HP":
                        P.UpdateIVs(0, int.Parse(Input));
                        break;

                    case "Attack":
                        P.UpdateIVs(1, int.Parse(Input));
                        break;

                    case "Defense":
                        P.UpdateIVs(2, int.Parse(Input));
                        break;

                    case "SpAtk":
                        P.UpdateIVs(3, int.Parse(Input));
                        break;

                    case "SpDef":
                        P.UpdateIVs(4, int.Parse(Input));
                        break;

                    case "Speed":
                        P.UpdateIVs(5, int.Parse(Input));
                        break;
                }
                break;
        }
        TeamController.UpdatePokemon(P, Slot);

    }

    public void SetName(string s)
    {
        s = char.ToUpper(s[0]) + s.Substring(1);
        Name.text = $"Name: {s}";
    }
}
