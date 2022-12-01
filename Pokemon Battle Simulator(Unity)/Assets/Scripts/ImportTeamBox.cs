using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportTeamBox : MonoBehaviour
{
    [SerializeField] private GameObject BattleSetupController;
    private TMPro.TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = transform.Find("Text Area").transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void SendTeamImportText()
    {
        if(Text.text != null)
        {
            BattleSetupController.GetComponent<SetupController>().SendTeamImport(Text.text);
        }
    }
}
