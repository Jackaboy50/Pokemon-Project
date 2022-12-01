using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
    private Stack<Canvas> BackStack = new Stack<Canvas>();
    private Canvas[] Canvasses;
    private GameObject Back;
    private Canvas Current;
    [SerializeField] private Canvas[] test;
    // Start is called before the first frame update
    void Start()
    {
        Back = GameObject.Find("Back");
        Back.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Canvasses = FindObjectsOfType<Canvas>();
        foreach (Canvas c in Canvasses)
        {
            if (c.enabled == true)
            {
                Back.transform.SetParent(GameObject.Find(c.name).transform, true);
                Current = transform.parent.gameObject.GetComponent<Canvas>();
            }
        }
        if (Back.transform.parent.name == "StartCanvas")
        {
            Back.transform.gameObject.SetActive(false);
        }
        else
        {
            Back.transform.gameObject.SetActive(true);
        }
        test = BackStack.ToArray();
    }

    public void OnClick()
    {
        Current.enabled = false;
        BackStack.Pop().enabled = true;
    }

    public void Push(Canvas c)
    {
        BackStack.Push(c);
    }
}
