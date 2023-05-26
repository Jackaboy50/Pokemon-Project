using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pokemon_Battle_Sim__Console_
{
    public class Move
    {
        private Functions fn = new Functions();
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public string Name { get; private set; }
        public PType Type { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public string TypeName { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public string Info { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public int BaseDamage { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public string AttackType { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public int PP { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] public int Accuracy { get; private set; }

        public Move(string n, PType T, string I, int BD, string AT, int P, int a)
        {
            Name = n;
            Type = T;
            TypeName = T.Name;
            BaseDamage = BD;
            AttackType = AT;
            PP = P;
            Info = I;
            Accuracy = a;
        }

        [JsonConstructor] public Move()
        {

        }

        public void SetType()
        {
            Type = fn.FindType(TypeName);
        }

        public void DecreasePP()
        {
            PP -= 1;
        }


    }
}
