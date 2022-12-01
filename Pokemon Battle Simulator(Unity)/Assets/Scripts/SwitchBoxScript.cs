using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwitchBoxScript : MonoBehaviour
{
    [SerializeField] private Image PokemonImage;
    [SerializeField] private TextMeshProUGUI PokemonName;
    private Sprite PokemonSprite;
    private Classes.ActivePokemon Pokemon;
    private bool SpriteSet = false;

    public void OnClick()
    {
        GameObject.Find("BattleController").GetComponent<BattleControllerScripts>().SwitchPokemon(PokemonName.text);
    }
    public void SetPokemon(Classes.ActivePokemon P, Sprite S)
    {
        Pokemon = P;
        PokemonSprite = S;
        PokemonImage.sprite = S;
        PokemonName.text = P.ReturnName();
    }

    public string ReturnPokemonName()
    {
        return PokemonName.text;
    }

    private void Start()
    {
        PokemonImage.enabled = false;
    }

    private void Update()
    {
        if(SpriteSet == false)
        {
            PokemonImage.sprite = PokemonSprite;
            SpriteSet = true;
            PokemonImage.enabled = true;
        }
    }
}
