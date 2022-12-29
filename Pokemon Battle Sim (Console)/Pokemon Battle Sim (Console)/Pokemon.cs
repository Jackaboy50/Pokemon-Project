using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Pokemon
    {
        [JsonIgnore] protected Functions fn = new Functions();
        [JsonIgnore] private string ImageRef;
        [JsonRequired] private string DexNum;
        [JsonRequired] private string Name;
        [JsonIgnore] public string Nickname; // assigned by the player, null by default 
        [JsonIgnore] public string Gender; //F , M or N for the respective genders
        [JsonIgnore] public int Level = 1; // 1 - 100 dependent on ruleset
        [JsonIgnore] public Ability Ability;
        [JsonIgnore] public bool Shiny;
        [JsonIgnore] public Item Helditem;
        [JsonRequired] protected int[] BaseStats = new int[6]; //Basestats should be webscraped and definite values
        [JsonIgnore] public int[] IV = new int[6] { 1, 1, 1, 1, 1, 1 }; //IV's should be adjustable from 1 - 31 and they affect the base stats | in the order  HP , Atk , Def , SpA , SpD , SPe
        [JsonIgnore] public int[] EV = new int[6] { 1, 1, 1, 1, 1, 1 }; //EV's will be inputted and adjusted by the player so this needs to be easily accessible | in the order  HP , Atk , Def , SpA , SpD , SPe
        [JsonIgnore] protected PType Type1;
        [JsonIgnore] protected PType Type2;
        [JsonRequired] protected string Type1Name;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)] protected string Type2Name;
        [JsonIgnore] public string Nature;
        [JsonIgnore] public List<Move> Moveset = new List<Move>();

        public Pokemon(string n, PType T1, PType T2, int[] B)
        {
            Name = n;
            Type1 = T1;
            Type1Name = T1.ReturnName();
            Type2 = T2;
            Type2Name = T2 != null ? T2.ReturnName() : string.Empty;
            BaseStats = B;

            string[] regionalCheck = Name.Split(" ");
            if(regionalCheck.Length > 1)
            {
                ImageRef = WebScraper.GetPokemonImageRef(regionalCheck[1]);
                DexNum = WebScraper.GetDexNum(regionalCheck[1]);
            }
            else
            {
                ImageRef = WebScraper.GetPokemonImageRef(Name);
                DexNum = WebScraper.GetDexNum(Name);
            }
            
        }

        [JsonConstructor] public Pokemon()
        {

        }

        public void SetTypes()
        {
            Type1 = fn.FindType(Type1Name);
            Type2 = Type2Name != null ? fn.FindType(Type2Name) : null;
        }

        public void AddMove(string MoveName)
        {
            Moveset.Add(WebScraper.GetMove(MoveName));
        }

        public string ReturnName()
        {
            return Name;
        }

        public PType ReturnType1()
        {
            return Type1;
        }

        public PType ReturnType2()
        {
            return Type2;
        }

        public int[] ReturnBaseStats()
        {
            return BaseStats;
        }

        public string ReturnDexNum()
        {
            return DexNum;
        }

        public void UpdateIVs(int index, int value)
        {
            if (value >= 1 && value <= 31)
            {
                IV[index] = value;
            }
            else
            {
                //produce error
            }
        }

    }
}
