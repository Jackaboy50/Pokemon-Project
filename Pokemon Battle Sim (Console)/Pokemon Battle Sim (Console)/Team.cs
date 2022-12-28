using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Team
    {
        private string TeamName;
        private Pokemon[] Pokemon;
        private Pokemon Slot1;
        private Pokemon Slot2;
        private Pokemon Slot3;
        private Pokemon Slot4;
        private Pokemon Slot5;
        private Pokemon Slot6;

        public Team(string t)
        {
            TeamName = t;
            Pokemon = new Pokemon[6];
            Pokemon[0] = Slot1;
            Pokemon[1] = Slot2;
            Pokemon[2] = Slot3;
            Pokemon[3] = Slot4;
            Pokemon[4] = Slot5;
            Pokemon[5] = Slot6;
        }

        public void EditPokemon(int slot)
        {
            Pokemon TempPokemon = Pokemon[slot - 1];
        }

        public Pokemon[] ReturnList()
        {
            return Pokemon;
        }

        public void SetList(Pokemon[] p)
        {
            Pokemon = p;
        }

        public string ReturnTeamName()
        {
            return TeamName;
        }
    }
}
