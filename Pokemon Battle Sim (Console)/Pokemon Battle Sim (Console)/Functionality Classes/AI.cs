using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Functionality_Classes
{
    internal static class AI
    {
        public static void CreateTeam(int aiTier)
        {
            Pokemon Slot1;
            Pokemon Slot2;
            Pokemon Slot3;
            Pokemon Slot4;
            Pokemon Slot5;
            Pokemon Slot6;
            Team T;
            switch (aiTier)
            {
                case 0:
                    Slot1 = WebScraper.GetPokemon("Venusaur");
                    Slot1.Level = 50;
                    Slot1.AddMove("Giga Drain");
                    Slot1.AddMove("Sludge Bomb");
                    Slot1.AddMove("Earthquake");
                    Slot1.AddMove("Hyper Beam");

                    Slot2 = WebScraper.GetPokemon("Charizard");
                    Slot2.Level = 50;
                    Slot2.AddMove("Dragon Claw");
                    Slot2.AddMove("Flamethrower");
                    Slot2.AddMove("Outrage");
                    Slot2.AddMove("Crunch");

                    Slot3 = WebScraper.GetPokemon("Blastoise");
                    Slot3.Level = 50;
                    Slot3.AddMove("Hydro Pump");
                    Slot3.AddMove("Ice Beam");
                    Slot3.AddMove("Dragon Pulse");
                    Slot3.AddMove("Dark Pulse");
                    T = new Team("Tier 1 Team");
                    ActivePokemon[] newTeam = new ActivePokemon[] {Functions.ConvertToActive(Slot1),Functions.ConvertToActive(Slot2), Functions.ConvertToActive(Slot3) };
                    T.SetList(newTeam);
                    break;
            }
        }

        public static Move PickMove(int aiTier, ActivePokemon P1, ActivePokemon P2)
        {
            int Index = 0;
            Random rand = new Random();
            switch (aiTier)
            {
                case 0:
                    Index = rand.Next(0, P1.Moveset.Count - 1);
                    return P1.Moveset[Index];

                case 1:
                    return P1.Moveset[BattleCalculator.BestMove(P1, P2)];
            }
            return P1.Moveset[0];
        }

        public static int SwitchPokemon(int aiTier, ActivePokemon Opponent, List<string> FaintedMembers, ActivePokemon[] Team)
        {
            int Index;
            Random rand = new Random();
            switch (aiTier)
            {
                case 0:
                    Index = rand.Next(0, Team.Length);
                    if (FaintedMembers.Contains(Team[Index].Name.ToLower()) == false)
                    {
                        return Index;
                    }
                    else
                    {
                        for (int i = Index; i < Team.Length; i++)
                        {
                            if (FaintedMembers.Contains(Team[i].Name.ToLower()) == false)
                            {
                                return i;
                            }
                        }
                    }
                    break;
            }
            return -1;
        }
    }
}
