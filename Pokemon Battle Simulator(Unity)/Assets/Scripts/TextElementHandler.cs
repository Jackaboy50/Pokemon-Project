using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextElementHandler : MonoBehaviour
{
    private string Type;
    private TextMeshProUGUI TextElement;
    private string Text;
    private bool Set = false;
    private GameObject Content;
    [SerializeField] private TMP_FontAsset Font;
    // Start is called before the first frame update
    void Start()
    {
        TextElement = transform.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(Set == false)
        {
            switch (Type)
            {
                case "Turn":
                    TextElement.alignment = TextAlignmentOptions.Center;
                    TextElement.font = Font;
                    TextElement.fontSize = 70;
                    TextElement.text = Text;
                    Set = true;
                    break;

                case "Change":
                    TextElement.font = Font;
                    TextElement.fontSize = 30;
                    TextElement.text = Text;
                    Set = true;
                    break;

                case "Default":
                    TextElement.alignment = TextAlignmentOptions.Left;
                    TextElement.font = Font;
                    TextElement.fontSize = 36;
                    TextElement.text = Text;
                    Set = true;
                    break;

            }
        }
    }

    public void SetAttributes(string T, string t)
    {
        Type = T;
        Text = t;
    }

    public void EnableElement()
    {
        transform.GetComponent<TextMeshProUGUI>().enabled = true;
    }
}
