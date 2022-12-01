using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCycler : MonoBehaviour
{
    private Canvas[] Canvasses;
    private int Index = 0;

    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;

    private void Update()
    {
        if(CheckCanvasses() == true)
        {
            Index = 0;
            transform.SetParent(Canvasses[Index].transform, false);
            Left.transform.SetParent(Canvasses[Index].transform, false);
            Right.transform.SetParent(Canvasses[Index].transform, false);
        }
    }
    public void SetCanvasses(Canvas[] c)
    {
        Canvasses = c;
    }

    private bool CheckCanvasses()
    {
        int count = 0;
       for (int i = 0; i < Canvasses.Length; i++)
        {
            if(Canvasses[i].enabled == false)
            {
                count++;
            }
        }
        if (count == 3)
            return true;

        return false;
    }

    public void OnClick()
    {
        switch (transform.name)
        {
            case "right":
                Canvasses[Index].GetComponent<Canvas>().enabled = false;
                if(Index != 2)
                {
                    Index++;
                }
                else
                {
                    Index = 0;
                }
                transform.SetParent(Canvasses[Index].transform, false);
                Left.transform.SetParent(Canvasses[Index].transform, false);
                Canvasses[Index].GetComponent<Canvas>().enabled = true;
                break;

            case "left":
                Canvasses[Index].GetComponent<Canvas>().enabled = false;
                if (Index != 0)
                {
                    Index--;
                }
                else
                {
                    Index = 2;
                }
                transform.SetParent(Canvasses[Index].transform, false);
                Right.transform.SetParent(Canvasses[Index].transform, false);
                Canvasses[Index].GetComponent<Canvas>().enabled = true;
                break;
        }
    }
}
