using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseTextScript : MonoBehaviour
{
    private bool Insantiated = false;
    [SerializeField] private int FontSize;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Button button;
    [SerializeField] private Image Loading;
    [Header("Canvasses")]
    [SerializeField] private Canvas Startcanvas;
    [SerializeField] private Canvas BattleSetupCanvas;
    private Canvas NextCanvas;
    [SerializeField] private Canvas TeamsCanvas;
    private GameObject Back;
    // Start is called before the first frame update
    void Start()
    {
        Back = GameObject.Find("Back");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        FontSize = FontSize + 1;
        Text.fontSize = FontSize;
    }

    public void PointerExit()
    {
        FontSize = FontSize - 1;
        Text.fontSize = FontSize;
    }

    public void OnClick()
    {
        if(button.name == "PlayButton")
        {
            switch (Insantiated)
            {
                case true:
                    Startcanvas.enabled = false;
                    Back.SetActive(true);
                    Back.SendMessage("Push", Startcanvas);
                    GameObject.Find("BattleSetupCanvas").GetComponent<Canvas>().enabled = true;
                    break;

                case false:
                    Startcanvas.enabled = false;
                    Back.SetActive(true);
                    Back.SendMessage("Push", Startcanvas);
                    NextCanvas = BattleSetupCanvas;
                    Instantiate(NextCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                    GameObject.Find("BattleSetupCanvas(Clone)").name = "BattleSetupCanvas";
                    NextCanvas.enabled = true;
                    Insantiated = true;
                    break;
            }
    }

        if(button.name == "TeamBuilderButton")
        {
            switch (Insantiated)
            {
                case true:
                    Startcanvas.enabled = false;
                    Back.SetActive(true);
                    Back.SendMessage("Push", Startcanvas);
                    GameObject.Find("PokemonCanvas").GetComponent<Canvas>().enabled = true;
                    break;

                case false:
                    Startcanvas.enabled = false;
                    Back.SetActive(true);
                    Back.SendMessage("Push", Startcanvas);
                    NextCanvas = TeamsCanvas;
                    Instantiate(NextCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                    GameObject.Find("PokemonCanvas(Clone)").name = "PokemonCanvas";
                    NextCanvas.enabled = true;
                    Insantiated = true;
                    break;
            }
        }

        if(button.name == "SettingsButton")
        {

        }

        if(button.name == "AboutButton")
        {

        }
    }
}
