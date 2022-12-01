using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private Canvas Current;
    [SerializeField] private List<Canvas> Previous;
    [SerializeField] private Canvas[] Canvasses;
    private GameObject Back;
    // Start is called before the first frame update
    void Start()
    {
        Back = GameObject.Find("Back");
        Back.transform.gameObject.SetActive(false);
        Current = transform.parent.gameObject.GetComponent<Canvas>();
        foreach(Canvas c in Canvasses)
        {
            if(c.name == "StartCanvas")
            {
                Previous.Add(c);
            }
        }
    }

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
    }
    public void OnClick()
    {
        Current.enabled = false;
        GameObject.Find(Previous[0].name).GetComponent<Canvas>().enabled = true;
        Previous.RemoveAt(0);
    }

    public void SetPrevious(Canvas p)
    {
        Previous.Insert(0, p);
    }
}
