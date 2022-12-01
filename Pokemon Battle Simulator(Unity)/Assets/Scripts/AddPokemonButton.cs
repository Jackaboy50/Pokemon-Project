using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class AddPokemonButton : MonoBehaviour
{
    [SerializeField] private GameObject PokemonPrefab;
    int counter = 0;
    private Team T;
    public void OnClick()
    {
        Instantiate(PokemonPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, transform.parent.gameObject.transform);
        GameObject.Find("PokemonButton(Clone)").gameObject.GetComponent<PokemonButtonScript>().SetSlot(counter);
        GameObject.Find("PokemonButton(Clone)").gameObject.name = $"Slot{counter + 1}Button";
        transform.position = new Vector2(transform.position.x, transform.position.y - 150);
        transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
        counter++;
        if(counter == 6)
        {
            transform.gameObject.SetActive(false);
        }
    }
    public void SetTeam(Team t)
    {
        T = t;
    }
}
