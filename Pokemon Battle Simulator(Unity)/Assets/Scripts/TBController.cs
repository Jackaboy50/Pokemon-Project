using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class TBController : MonoBehaviour
{
    public int TeamNumber = 0;
    public int TeamSlotNumber = 1;
    private List<Team> Teams = new List<Team>();
    private TeamCanvasController[] TCControllers;
    [Header("Buttons")]
    [SerializeField] private GameObject[] TeamButtons;
    // Update is called once per frame
    void Update()
    {
        TeamButtons = GameObject.FindGameObjectsWithTag("TeamButton");
        TeamNumber = TeamButtons.Length;
    }

    public void AddTeam(Team T)
    {
        Teams.Add(T);
    }
}
