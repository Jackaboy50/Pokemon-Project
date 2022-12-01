using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class PokemonButtonScript : MonoBehaviour
{
    private bool Instantiated = false;
    [SerializeField] private Canvas PokemonCanvas;
    [SerializeField] private Canvas PokemonStatCanvas;
    [SerializeField] private Canvas PokemonMovesetCanvas;
    private Canvas newPokemonCanvas; 
    private Canvas TeamCanvas;
    private GameObject Back;
    [SerializeField] private int TeamSlotNumber;
    private Pokemon P;
    private int counter;
    private float clicktimer = 0.17f;
    [SerializeField] private TextMeshProUGUI NameChangerText;
    private bool HasPokemon = false;
    private Functions fn = new Functions();
    [SerializeField] private RawImage Pokemon;
    private Texture2D PokemonTexture;
    private bool setImage = false;
    // Start is called before the first frame update
    void Start()
    {
        TeamCanvas = transform.GetComponentInParent<Canvas>();
        Back = GameObject.Find("Back");
        fn.GenTypes();
    }

    // Update is called once per frame
    void Update()
    {
        if(PokemonTexture != null && setImage == false)
        {
            Pokemon.texture = PokemonTexture;
            Pokemon.enabled = true;
            setImage = true;   
        }
    }

    public void OnClick()
    {
        counter++;
        if (counter == 1)
        {
            StartCoroutine("DoubleClick");
        }
    }

    IEnumerator GetTexture(string refurl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(refurl);
        yield return www.SendWebRequest();
        PokemonTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
    }

    IEnumerator DoubleClick()
    {
        yield return new WaitForSeconds(clicktimer);
        if (counter > 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            if(HasPokemon != false && setImage != false)
            {
                switch (Instantiated)
                {
                    case false:
                        Instantiate(PokemonCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                        newPokemonCanvas = GameObject.Find("[Name]PokemonCanvas(Clone)").GetComponent<Canvas>();

                        TeamCanvas.enabled = false;
                        Back.SendMessage("Push", TeamCanvas);
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("PokemonController").GetComponent<PokemonController>().SetSlotNum(TeamSlotNumber);
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("PokemonController").GetComponent<PokemonController>().SetName(P.ReturnName());
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("PokemonController").GetComponent<PokemonController>().SetPokemon(P);
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("PokemonController").GetComponent<PokemonController>().SetPokemon(P);
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("PokemonController").GetComponent<PokemonController>().SetImage(Pokemon.texture);
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("PokemonController").GetComponent<PokemonController>().SetController(transform.parent.Find("TeamController").GetComponent<TeamCanvasController>());
                        

                        Instantiate(PokemonStatCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                        GameObject.Find("[Name]StatCanvas(Clone)").GetComponent<Canvas>().enabled = false;
                        GameObject.Find("[Name]StatCanvas(Clone)").transform.Find("StatController").GetComponent<StatControllerScript>().SetBasestats(P.ReturnBaseStats());
                        GameObject.Find("[Name]StatCanvas(Clone)").transform.Find("StatController").GetComponent<StatControllerScript>().SetName(P.ReturnName());
                        GameObject.Find("[Name]StatCanvas(Clone)").transform.Find("StatController").GetComponent<StatControllerScript>().SetImage(Pokemon.texture);



                        Instantiate(PokemonMovesetCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                        GameObject.Find("[Name]MovesetCanvas(Clone)").GetComponent<Canvas>().enabled = false;
                        GameObject.Find("[Name]MovesetCanvas(Clone)").transform.Find("MovesetController").GetComponent<MovesetControllerScript>().SetName(P.ReturnName());
                        GameObject.Find("[Name]MovesetCanvas(Clone)").transform.Find("MovesetController").GetComponent<MovesetControllerScript>().SetImage(Pokemon.texture);

                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("left").GetComponent<MenuCycler>().SetCanvasses(new Canvas[] { GameObject.Find("[Name]PokemonCanvas(Clone)").GetComponent<Canvas>(), GameObject.Find("[Name]StatCanvas(Clone)").GetComponent<Canvas>(), GameObject.Find("[Name]MovesetCanvas(Clone)").GetComponent<Canvas>() });
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.Find("right").GetComponent<MenuCycler>().SetCanvasses(new Canvas[] { GameObject.Find("[Name]PokemonCanvas(Clone)").GetComponent<Canvas>(), GameObject.Find("[Name]StatCanvas(Clone)").GetComponent<Canvas>(), GameObject.Find("[Name]MovesetCanvas(Clone)").GetComponent<Canvas>() });
                        GameObject.Find("[Name]PokemonCanvas(Clone)").transform.name = $"Slot:{TeamSlotNumber}_Canvas";
                        GameObject.Find($"Slot:{TeamSlotNumber}_Canvas").GetComponent<Canvas>().enabled = true;
                        GameObject.Find("[Name]StatCanvas(Clone)").transform.name = $"Slot:{TeamSlotNumber}_StatCanvas";
                        GameObject.Find("[Name]MovesetCanvas(Clone)").transform.name = $"Slot:{TeamSlotNumber}_MovesetCanvas";
                        
                        Instantiated = true;
                        break;

                    case true:
                        TeamCanvas.enabled = false;
                        Back.SendMessage("Push", TeamCanvas);
                        newPokemonCanvas.enabled = true;
                        break;
                }
            }  
        }
        counter = 0;
    }

    public void SetSlot(int i)
    {
        TeamSlotNumber = i;
    }

    public void ChangeText()
    {
        string Input = transform.Find("NameChanger").transform.Find("Text Area").transform.Find("Text").GetComponent<TextMeshProUGUI>().text.ToString();
        Input = Input.Remove(Input.Length - 1);
        P = WebScraper.GetPokemon(Input);
        setImage = false;
        PokemonTexture = null;
        StartCoroutine(GetTexture(WebScraper.GetPokemonImageRef(P.ReturnName())));
        transform.GetComponent<Button>().interactable = true;
        Input = char.ToUpper(Input[0]) + Input.Substring(1);
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = Input;
        transform.Find("NameChanger").gameObject.SetActive(false);
        transform.Find("Name").gameObject.SetActive(true);
        transform.Find("NameChanger").transform.Find("Text Area").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Enter Pokemon Name...";
        HasPokemon = true;
    }
}
