using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeIconSetter : MonoBehaviour
{
    [Header("Type Icons")]
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
    public void SetPos(int x, int y)
    {
        transform.position = new Vector2(x, y);
    }
    public void SetType(string TypeName)
    {
        switch (TypeName)
        {
            case "Bug":
                transform.GetComponent<Image>().sprite = Bug;
                break;
            case "Dark":
                transform.GetComponent<Image>().sprite = Dark;
                break;
            case "Dragon":
                transform.GetComponent<Image>().sprite = Dragon;
                break;
            case "Electric":
                transform.GetComponent<Image>().sprite = Electric;
                break;
            case "Fairy":
                transform.GetComponent<Image>().sprite = Fairy;
                break;
            case "Fighting":
                transform.GetComponent<Image>().sprite = Fighting;
                break;
            case "Fire":
                transform.GetComponent<Image>().sprite = Fire;
                break;
            case "Flying":
                transform.GetComponent<Image>().sprite = Flying;
                break;
            case "Ghost":
                transform.GetComponent<Image>().sprite = Ghost;
                break;
            case "Ground":
                transform.GetComponent<Image>().sprite = Ground;
                break;
            case "Ice":
                transform.GetComponent<Image>().sprite = Ice;
                break;
            case "Normal":
                transform.GetComponent<Image>().sprite = Normal;
                break;
            case "Poison":
                transform.GetComponent<Image>().sprite = Poison;
                break;
            case "Psychic":
                transform.GetComponent<Image>().sprite = Psychic;
                break;
            case "Rock":
                transform.GetComponent<Image>().sprite = Rock;
                break;
            case "Steel":
                transform.GetComponent<Image>().sprite = Steel;
                break;
            case "Water":
                transform.GetComponent<Image>().sprite = Water;
                break;
            case "Grass":
                transform.GetComponent<Image>().sprite = Grass;
                break;
        }
        transform.GetComponent<Image>().enabled = true;
    }
}
