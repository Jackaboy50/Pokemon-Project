using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class PType
    {
        private string Name;
        private Functions fn = new Functions();
        private List<string> Weaknesses = new List<string>();
        private List<string> Resistances = new List<string>();
        private List<string> Immunities = new List<string>();

        public PType(string n, List<string> W, List<string> R)
        {
            Name = n;
            Weaknesses = W;
            Resistances = R;
        }
        public PType(string n, List<string> W, List<string> R, List<string> I)
        {
            Name = n;
            Weaknesses = W;
            Resistances = R;
            Immunities = I;
        }

        public string ReturnName()
        {
            return Name;
        }

        public List<string> ReturnWeaknesses()
        {
            return Weaknesses;
        }

        public List<string> ReturnResistances()
        {
            return Resistances;
        }

        public List<string> ReturnImmunities()
        {
            if (Immunities != null)
            {
                return Immunities;
            }
            return null;
        }
    }
}
