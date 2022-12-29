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
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private string Name;
        private PType Type;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private string TypeName;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private string Info;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private int BaseDamage;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private string AttackType;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private int PP;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)][JsonRequired] private int Accuracy;

        public Move(string n, PType T, string I, int BD, string AT, int P, int a)
        {
            Name = n;
            Type = T;
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

        public int ReturnPP()
        {
            return PP;
        }
        public string ReturnAttackType()
        {
            return AttackType;
        }
        public int ReturnBaseDamage()
        {
            return BaseDamage;
        }
        public string ReturnInfo()
        {
            return Info;
        }

        public string ReturnName()
        {
            return Name;
        }

        public PType ReturnType()
        {
            return Type;
        }

        public int ReturnAccuracy()
        {
            return Accuracy;
        }

        public void DecreasePP()
        {
            PP -= 1;
        }


    }
}
