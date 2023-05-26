using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Team
    {
        public string TeamName { get; private set; }
        public ActivePokemon[] Pokemon { get; private set; }
        public ActivePokemon Slot1 { get; private set; }
        public ActivePokemon Slot2 { get; private set; }
        public ActivePokemon Slot3 { get; private set; }
        public ActivePokemon Slot4 { get; private set; }
        public ActivePokemon Slot5 { get; private set; }
        public ActivePokemon Slot6 { get; private set; }

        public Team(string t)
        {
            TeamName = t;
            Pokemon = new ActivePokemon[] { Slot1, Slot2, Slot3, Slot4, Slot5, Slot6 };
        }

        public void EditPokemon(int slot)
        {
            Pokemon TempPokemon = Pokemon[slot - 1];
        }

        public void SetList(ActivePokemon[] p)
        {
            Pokemon = p;
        }
    }
}
