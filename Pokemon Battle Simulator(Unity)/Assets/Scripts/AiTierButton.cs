using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTierButton : MonoBehaviour
{
    [SerializeField] private GameObject BattleSetupController;
    public void OnClick()
    {
        switch (transform.name)
        {
            case "1":
                BattleSetupController.GetComponent<SetupController>().SetAiTier(1);
                break;

            case "2":
                BattleSetupController.GetComponent<SetupController>().SetAiTier(2);
                break;

            case "3":
                BattleSetupController.GetComponent<SetupController>().SetAiTier(3);
                break;

            case "4":
                BattleSetupController.GetComponent<SetupController>().SetAiTier(4);
                break;

            case "5":
                BattleSetupController.GetComponent<SetupController>().SetAiTier(5);
                break;
        }
    }
}
