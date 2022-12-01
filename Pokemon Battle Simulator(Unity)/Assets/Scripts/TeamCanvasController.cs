using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class TeamCanvasController : MonoBehaviour
{
    private string TeamName;
    private Team T = new Team(" ");
    private PokemonController[] PKMNControllers;
    private Functions fn = new Functions();
    public void SetTeamName(string TN)
    {
        TeamName = TN;
        T.SetTeamName(TN);
    }

    public string[] ExportTeam()
    {
        return fn.ExportTeam(T);
    }

    public void UpdatePokemon(Pokemon P, int slot)
    {
        Pokemon[] Temp = T.ReturnList();
        switch (slot)
        {
            case 1:
                Temp[slot - 1] = P;
                T.SetList(Temp);

                break;
            case 2:
                Temp[slot - 1] = P;
                T.SetList(Temp);
                break;
            case 3:
                Temp[slot - 1] = P;
                T.SetList(Temp);
                break;
            case 4:
                Temp[slot - 1] = P;
                T.SetList(Temp);
                break;
            case 5:
                Temp[slot - 1] = P;
                T.SetList(Temp);
                break;
            case 6:
                Temp[slot - 1] = P;
                T.SetList(Temp);
                break;
        }
    }
}
