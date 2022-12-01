using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField : MonoBehaviour
{
    private Button Button;
    private TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Button = transform.parent.gameObject.GetComponent<Button>();
        Text = transform.Find("Text Area").gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        transform.gameObject.SetActive(false);
    }

    public void ChangeText()
    {
        Button.SendMessage("ChangeText", Text.text);
    }
}
