using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Item
    {
        private string Name;
        private string Info;
        private float DamageMultiplier = 0;
        private string ImageRef;

        public Item(string N, string I, float DM)
        {
            Name = N;
            Info = I;
            DamageMultiplier = DM;
        }

        public string ReturnName()
        {
            return Name;
        }
    }
}
