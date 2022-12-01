using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatControllerScript : MonoBehaviour
{
    [Header("Basestat Values")]
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI Attack;
    [SerializeField] private TextMeshProUGUI Defense;
    [SerializeField] private TextMeshProUGUI SpAtk;
    [SerializeField] private TextMeshProUGUI SpDef;
    [SerializeField] private TextMeshProUGUI Speed;

    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private RawImage PokemonImage;
    public void SetBasestats(int[] Basestats)
    {
        HP.text = Basestats[0].ToString();
        Attack.text = Basestats[1].ToString();
        Defense.text = Basestats[2].ToString();
        SpAtk.text = Basestats[3].ToString();
        SpDef.text = Basestats[4].ToString();
        Speed.text = Basestats[5].ToString();
    }

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
}
