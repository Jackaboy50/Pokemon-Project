using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovesetControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI PP1;
    [SerializeField] private TextMeshProUGUI PP2;
    [SerializeField] private TextMeshProUGUI PP3;
    [SerializeField] private TextMeshProUGUI PP4;
    [SerializeField] private RawImage PokemonImage;
    [SerializeField] private GameObject TypeIcon;

    private int xPos = -200;
    public void SetName(string s)
    {
        s = char.ToUpper(s[0]) + s.Substring(1);
        Name.text = $"Name: {s}";
    }

    public void SetImage(Texture s)
    {
        PokemonImage.texture = s;
        PokemonImage.enabled = true;
    }

    public void CreateIcon(int Move, Classes.Type T, int pp)
    {
        switch (Move)
        {
            case 0:
                if(transform.parent.Find("Move1Type") == null)
                {
                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-200, 240);
                    transform.parent.Find("TypeIcon(Clone)").name = "Move1Type";
                }
                else
                {
                    transform.parent.Find("Move1Type").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                }
                PP1.text = pp.ToString();
                break;

            case 1:
                if(transform.parent.Find("Move2Type") == null)
                {
                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-200, 100);
                    transform.parent.Find("TypeIcon(Clone)").name = "Move2Type";
                }
                else
                {
                    transform.parent.Find("Move2Type").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                }
                PP2.text = pp.ToString();
                break;

            case 2:
                if(transform.parent.Find("Move3Type") == null)
                {
                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-200, -40);
                    transform.parent.Find("TypeIcon(Clone)").name = "Move3Type";
                }
                else
                {
                    transform.parent.Find("Move3Type").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                }
                PP3.text = pp.ToString();
                break;

            case 3:
                if(transform.parent.Find("Move4Type") == null)
                {
                    Instantiate(TypeIcon, transform.parent);
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                    transform.parent.Find("TypeIcon(Clone)").GetComponent<TypeIconSetter>().SetPos(-200, -180);
                    transform.parent.Find("TypeIcon(Clone)").name = "Move4Type";
                }
                else
                {
                    transform.parent.Find("Move4Type").GetComponent<TypeIconSetter>().SetType(T.ReturnName());
                }
                PP4.text = pp.ToString();
                break;
        }
    }
}
