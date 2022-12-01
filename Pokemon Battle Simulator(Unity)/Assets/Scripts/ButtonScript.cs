using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [Header("Button Properties")]
    [SerializeField] private Text text;
    [SerializeField] private bool clicked = false;
    [SerializeField] private Text[] MenuOptions = new Text[5];
    
    // Start is called before the first frame update
    void Start()
    {
        if(text.text == "Play")
        {
            MenuOptions[0] = text;
        }
    }
    public void PointerEnter()
    {
        text.fontSize = 50;
    }

    public void PointerExit()
    {
        if(clicked == false)
        {
            text.fontSize = 40;
        } 
    }

    public void OnClick()
    {
        text.fontSize = 50;
        clicked = true;
    }
}
