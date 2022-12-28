using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Ability
    {
        private string Name;
        private string Info;
        private int Multiplier;

        public Ability(string n, string i, int m)
        {
            Name = n;
            Info = i;
            Multiplier = m;
        }

        public string ReturnName()
        {
            return Name;
        }
    }
}
