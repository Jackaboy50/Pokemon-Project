using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Classes;

public class TeamButtonScript : MonoBehaviour
{
    [SerializeField] private int FontSize;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Button button;
    [SerializeField] private Canvas TeamsCanvas;
    [SerializeField] private Canvas PokemonCanvas;
    [SerializeField] private InputField NameChanger;
    [SerializeField] private TextMeshProUGUI NameChangerText;
    TBController TeamBuilderController;
    private GameObject Back;
    private Canvas newPokemonCanvas;
    private int counter;
    private float clicktimer = 0.17f;
    private bool Instantiated = false;
    private static Functions fn = new Functions();
    private Team T;
    // Start is called before the first frame update
    void Start()
    {
        TeamBuilderController = GameObject.Find("TeamBuilderController").GetComponent<TBController>();
        T = new Team($"Team {TeamBuilderController.TeamNumber}");
        Text.text = T.ReturnTeamName();
        Back = GameObject.Find("Back");
    }

    // Update is called once per frame
    void Update()
    {
        if (Instantiated == true)
        {
            newPokemonCanvas.name = $"{Text.text}_Canvas";
        }
        transform.gameObject.name = $"{Text.text}_Button";
    }

    public void OnClick()
    {
        counter++;
        if(counter == 1)
        {
            StartCoroutine("DoubleClick");
        }
    }

    IEnumerator DoubleClick()
    {
        yield return new WaitForSeconds(clicktimer);
        if(counter > 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            switch (Instantiated)
            {
                case false:
                    Instantiate(PokemonCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                    GameObject.Find("TeamsCanvas").GetComponent<Canvas>().enabled = false;
                    Back.SendMessage("Push", GameObject.Find("TeamsCanvas").gameObject.GetComponent<Canvas>());
                    newPokemonCanvas = GameObject.Find("PokemonCanvas(Clone)").GetComponent<Canvas>();
                    newPokemonCanvas.name = $"{Text.text}_Canvas";
                    newPokemonCanvas.gameObject.transform.Find("AddPokemon").GetComponent<AddPokemonButton>().SetTeam(T);
                    PokemonCanvas.enabled = true;
                    Instantiated = true;
                    break;

                case true:
                    GameObject.Find("TeamsCanvas").GetComponent<Canvas>().enabled = false;
                    Back.SendMessage("Push", GameObject.Find("TeamsCanvas").gameObject.GetComponent<Canvas>());
                    newPokemonCanvas.enabled = true;
                    break;
            }
        }
        counter = 0;
    }

    public void ChangeText(string Input)
    {
        T.SetTeamName(Input);
        Text.text = Input;
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        NameChangerText.text = "Enter Team Name...";
    }

    public Team GetTeam()
    {
        return T;
    }
}
