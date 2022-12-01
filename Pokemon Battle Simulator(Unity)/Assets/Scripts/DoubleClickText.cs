using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoubleClickText : MonoBehaviour
{
    private int counter;
    private float clicktimer = 0.17f;
    private TextMeshProUGUI Text;
    private InputField TextChanger;
    private TextMeshProUGUI TextChangerText;
    // Start is called before the first frame update
    void Start()
    {
        Text = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextChanger = transform.Find("NameChanger").GetComponent<InputField>();
        TextChangerText = TextChanger.transform.Find("Text Area").transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }
    public void OnClick()
    {
        counter++;
        if (counter == 1)
        {
            StartCoroutine("DoubleClick");
        }
    }

    IEnumerator DoubleClick()
    {
        yield return new WaitForSeconds(clicktimer);
        if (counter > 1)
        {
            Text.enabled = false;
            transform.GetChild(1).gameObject.SetActive(true);
        }
        counter = 0;
    }

    public void ChangeText(string Input)
    {
        Text.text = Input;
        TextChanger.gameObject.SetActive(false);
        Text.enabled = true;
        TextChangerText.text = "Enter Team Name...";
    }
}
