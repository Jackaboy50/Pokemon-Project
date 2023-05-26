using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pokemon_Battle_Sim__Console_
{
    public class Ability
    {
        [JsonRequired] private string Name;
        [JsonRequired] private string Info;
        [JsonRequired] private int Multiplier = 1;

        public Ability(string n, string i)
        {
            Name = n;
            Info = i;
        }
        
        public string ReturnName()
        {
            return Name;
        }
    }
}
