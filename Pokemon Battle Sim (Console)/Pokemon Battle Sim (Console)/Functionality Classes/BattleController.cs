using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    internal class BattleController
    {
        ActivePokemon[] Team1Container = new ActivePokemon[6];
        ActivePokemon[] Team2Container = new ActivePokemon[6];

        ActivePokemon Team1FieldPokemon;
        ActivePokemon Team2FieldPokemon;

        public void StartBattleAgainstAI()
        {

        }

        public void EndBattle()
        {
                
        }

        public void SwitchPokemon(ActivePokemon newP, int teamNum) 
        {
            switch (teamNum)
            {
                case 1:
                    Team1FieldPokemon = newP;
                    break;

                case 2:
                    Team2FieldPokemon = newP;
                    break;
            }
        }
    }
}
