using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using UnityEngine.UI;
using TMPro;

public class MoveBoxScript : MonoBehaviour
{
    [Header ("Move Boxes")]
    [SerializeField] private Sprite Bug;
    [SerializeField] private Sprite Dark;
    [SerializeField] private Sprite Dragon;
    [SerializeField] private Sprite Electric;
    [SerializeField] private Sprite Fairy;
    [SerializeField] private Sprite Fighting;
    [SerializeField] private Sprite Fire;
    [SerializeField] private Sprite Flying;
    [SerializeField] private Sprite Ghost;
    [SerializeField] private Sprite Ground;
    [SerializeField] private Sprite Ice;
    [SerializeField] private Sprite Normal;
    [SerializeField] private Sprite Poison;
    [SerializeField] private Sprite Psychic;
    [SerializeField] private Sprite Rock;
    [SerializeField] private Sprite Steel;
    [SerializeField] private Sprite Water;
    [SerializeField] private Sprite Grass;

    [SerializeField] private Button MoveBox;
    [SerializeField] private TextMeshProUGUI MoveName;
    [SerializeField] private TextMeshProUGUI PP;
    private bool MoveBoxSet = false;
    private Move M;
    private GameObject BattleController;
    private bool Available = false;
    private Functions fn = new Functions();
    private int InitialPP;
    private bool SetPP = false;

    // Start is called before the first frame update
    void Start()
    {
        fn.GenTypes();
        BattleController = GameObject.Find("BattleController");
    }

     void Update()
    {
        if (SetPP == false)
        {
            if(M != null)
            {
                InitialPP = M.ReturnPP();
                SetPP = true;
            }
        }
        if(MoveBoxSet == false)
        {
            switch (M.ReturnType().ReturnName())
            {
                case "Bug":
                    MoveBox.image.sprite = Bug;
                    MoveBoxSet = true;
                    break;
                case "Dark":
                    MoveBox.image.sprite = Dark;
                    MoveBoxSet = true;
                    break;
                case "Dragon":
                    MoveBox.image.sprite = Dragon;
                    MoveBoxSet = true;
                    break;
                case "Electric":
                    MoveBox.image.sprite = Electric;
                    MoveBoxSet = true;
                    break;
                case "Fairy":
                    MoveBox.image.sprite = Fairy;
                    MoveBoxSet = true;
                    break;
                case "Fighting":
                    MoveBox.image.sprite = Fighting;
                    MoveBoxSet = true;
                    break;
                case "Fire":
                    MoveBox.image.sprite = Fire;
                    MoveBoxSet = true;
                    break;
                case "Flying":
                    MoveBox.image.sprite = Flying;
                    MoveBoxSet = true;
                    break;
                case "Ghost":
                    MoveBox.image.sprite = Ghost;
                    MoveBoxSet = true;
                    break;
                case "Ground":
                    MoveBox.image.sprite = Ground;
                    MoveBoxSet = true;
                    break;
                case "Ice":
                    MoveBox.image.sprite = Ice;
                    MoveBoxSet = true;
                    break;
                case "Normal":
                    MoveBox.image.sprite = Normal;
                    MoveBoxSet = true;
                    break;
                case "Poison":
                    MoveBox.image.sprite = Poison;
                    MoveBoxSet = true;
                    break;
                case "Psychic":
                    MoveBox.image.sprite = Psychic;
                    MoveBoxSet = true;
                    break;
                case "Rock":
                    MoveBox.image.sprite = Rock;
                    MoveBoxSet = true;
                    break;
                case "Steel":
                    MoveBox.image.sprite = Steel;
                    MoveBoxSet = true;
                    break;
                case "Water":
                    MoveBox.image.sprite = Water;
                    MoveBoxSet = true;
                    break;

                case "Grass":
                    MoveBox.image.sprite = Grass;
                    MoveBoxSet = true;
                    break;
            }
        }
        MoveName.text = M.ReturnName();
        PP.text = $"{M.ReturnPP()}/{InitialPP}";
    }

    public void OnClick()
    {
        if(Available == false)
        {
            BattleController.SendMessage("RecieveMove", M);
        }
        Available = true;
    }

    public void SetMove(Move m)
    {
        M = m;
        transform.name = $"{M.ReturnName()} Box";
        MoveBoxSet = false;
    }

    public string ReturnName()
    {
        return MoveName.text;
    }

    public void SetAvailable()
    {
        Available = false;
    }
}
