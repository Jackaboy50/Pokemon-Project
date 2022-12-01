using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBattleButton : MonoBehaviour
{
    private Canvas BattleSetupCanvas;
    [SerializeField] private Canvas BattleCanvas;
    private GameObject Back;
    [SerializeField] private GameObject BattleSetupController;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().interactable = false;
        BattleSetupCanvas = transform.GetComponentInParent<Canvas>();
        Back = GameObject.Find("Back");
    }

    public void OnClick()
    {
        BattleSetupCanvas.enabled = false;
        Back.SendMessage("Push", BattleSetupCanvas);
        Instantiate(BattleCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject.Find("BattleCanvas(Clone)").name = "BattleCanvas";
        BattleCanvas.enabled = true;
        BattleSetupController.GetComponent<SetupController>().SendInfo();
    }
}
