using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportTeamButton : MonoBehaviour
{
    [SerializeField] private GameObject TeamController;

    public void Onclick()
    {
        TextEditor TE = new TextEditor();
        string[] export = TeamController.GetComponent<TeamCanvasController>().ExportTeam();
        foreach(string s in export)
        {
            TE.text += $"{s}{System.Environment.NewLine}";
        }
        TE.SelectAll();
        TE.Copy();
    }
}
