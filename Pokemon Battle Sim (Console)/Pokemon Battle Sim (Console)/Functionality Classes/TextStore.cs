using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class TextStore
    {
        public string SpaceLine = " ";
        public string TeamSeparator = "~";
        public string PKMNSeparator = "#";
        public string MakeTeamLine(string TeamName)
        {
            return $"TeamName:{TeamName}";
        }

        public string MakePokemonLine(string NN, string N, string G, Item I)
        {
            string IN = "";
            if (I != null)
            {
                IN = I.ReturnName();
            }
            if (G == null)
            {
                G = "N";
            }

            return $"{NN} ({N}) [{G}] @{IN}";
        }

        public string MakeLevelLine(int Level)
        {
            return $"Level: {Level}";
        }

        public string MakeAbilityLine(string Ability)
        {
            return $"Ability: {Ability}";
        }

        public string MakeEVLine(int[] EV)
        {
            return $"EVs: HP {EV[0]} / Atk {EV[1]} / Def {EV[2]} / SpA {EV[3]} / SpD {EV[4]} / SpE {EV[5]}";
        }

        public string MakeNatureLine(string Nature)
        {
            return $"Nature: {Nature}";
        }

        public string MakeShinyLine(bool Shiny)
        {
            if (Shiny == true)
            {
                return "Shiny: Yes";
            }
            else
            {
                return "Shiny: No";
            }
        }

        public string MakeMoveLine(Move Move)
        {
            return $"- {Move.Name}";
        }
    }
}
