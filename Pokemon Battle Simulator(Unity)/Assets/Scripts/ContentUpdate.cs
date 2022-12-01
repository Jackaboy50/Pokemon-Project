using UnityEngine;

public class ContentUpdate : MonoBehaviour
{
    [SerializeField] private GameObject TextElement;
    private AutoScrollDown ScrollScript;
    private int NumofTextElements;
    private void Start()
    {
        ScrollScript = transform.GetComponentInParent<AutoScrollDown>();
    }
    public void AddText(string Type, string Text)
    {
        Instantiate(TextElement, new Vector2(0, 0), Quaternion.identity, transform);
        GameObject.Find("TextElement(Clone)").GetComponent<TextElementHandler>().SetAttributes(Type, Text);
        ScrollScript.SendMessage("ScrollDown");
        GameObject.Find("TextElement(Clone)").GetComponent<TextElementHandler>().EnableElement();
        GameObject.Find("TextElement(Clone)").name = "TE";
    }
}
