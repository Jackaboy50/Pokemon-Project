using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPokemonMenu : MonoBehaviour
{
    private Canvas[] Menus;
    private Canvas Menu;
    private Canvas Stat;
    private Canvas Moveset;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        Menus = new Canvas[] { Menu, Stat, Moveset };
    }

    public void OnClick()
    {
        switch (transform.name)
        {
            case "LeftButton":
                if(index > 0)
                {
                    index -= 1;
                }
                else
                {
                    index = 2;
                }
                
                break;

            case "RightButton":
                if(index < 2)
                {
                    index += 1;
                }
                else
                {
                    index = 0;
                }
                break;
        }
    }
}
