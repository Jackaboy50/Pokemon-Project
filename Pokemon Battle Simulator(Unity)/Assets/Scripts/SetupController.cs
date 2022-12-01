using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class SetupController : MonoBehaviour
{
    [SerializeField] private int AiTiers = 1;
    [SerializeField] private string[] Import;
    private Team T;
    private Functions fn = new Functions();
    [SerializeField] private TMPro.TMP_InputField ImportBox;
    [SerializeField] private GameObject BattleController;
    [SerializeField] private GameObject StartButton;
    // Start is called before the first frame update
    void Start()
    {
        fn.GenTypes();
    }

    public void SetAiTier(int i)
    {
        AiTiers = i;
    }

    public void SendTeamImport(string s)
    {
        Import = s.Split('\n');
        List<string> Temp = new List<string>(Import);
        Temp.Add(System.Environment.NewLine);
        Import = Temp.ToArray();
        if(true)
        {
            T = fn.ImportTeam(Import);
            StartButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
        else
        {
            ImportBox.transform.Find("Text Area").transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = fn.ValidateTeamImport(Import);
            return;
        }
    }

    public void SendInfo()
    {
        GameObject BattleController = GameObject.Find("BattleController");
        BattleController.GetComponent<BattleControllerScripts>().SetBattleSetup(T, AiTiers);
    }
}
