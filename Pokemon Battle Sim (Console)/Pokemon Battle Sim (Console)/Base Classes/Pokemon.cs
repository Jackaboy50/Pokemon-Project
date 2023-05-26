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
        #region PokedexValues
        [JsonRequired] public string nationalDexNum { get; private set; }
        [JsonRequired] public string Name { get; private set; }
        [JsonRequired] public int[] BaseStats { get; protected set; } //Basestats should be webscraped and definite values
        [JsonIgnore] public PType Type1 { get; protected set; }
        [JsonIgnore] public PType Type2 { get; protected set; }
        [JsonRequired] protected string Type1Name;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)] protected string Type2Name;
        [JsonRequired] public List<string> possibleMoves { get; private set; }
        [JsonRequired] public List<string> featuredGames { get; private set; }
        [JsonRequired] public List<string> localDexNumbers { get; private set; }
        [JsonRequired] public int generation { get; private set; }
        #endregion
        #region PlayerVariables
        [JsonIgnore] public string Nickname; // assigned by the player, null by default 
        [JsonIgnore] public string Gender; //F , M or N for the respective genders
        [JsonIgnore] public int Level = 1; // 1 - 100 dependent on ruleset
        [JsonIgnore] public Ability Ability;
        [JsonIgnore] public bool Shiny;
        [JsonIgnore] public Item Helditem;
        [JsonIgnore] public string Nature;
        [JsonIgnore] public List<Move> Moveset = new List<Move>();
        [JsonIgnore] public int[] IV = new int[6] { 1, 1, 1, 1, 1, 1 }; //IV's should be adjustable from 1 - 31 and they affect the base stats | in the order  HP , Atk , Def , SpA , SpD , SPe
        [JsonIgnore] public int[] EV = new int[6] { 1, 1, 1, 1, 1, 1 }; //EV's will be inputted and adjusted by the player so this needs to be easily accessible | in the order  HP , Atk , Def , SpA , SpD , SPe
        #endregion
        public Pokemon(string n, PType T1, PType T2, int[] B, List<string> PM, List<string> FG, List<string> LDN)
        {
            Name = n;
            Type1 = T1;
            Type1Name = T1.ReturnName();
            Type2 = T2;
            Type2Name = T2 != null ? T2.ReturnName() : string.Empty;
            SetTypes();
            BaseStats = B;
            possibleMoves = PM;
            featuredGames = FG;
            localDexNumbers = LDN;
            string[] regionalCheck = Name.Split(" ");
            if(regionalCheck.Length > 1)
            {
                nationalDexNum = WebScraper.GetDexNum(regionalCheck[1]);
            }
            else
            {
                nationalDexNum = WebScraper.GetDexNum(Name);
            }
            SetGeneration();
        }
        [JsonConstructor] public Pokemon()
        { 
            if(Type1Name != null)
            {
                SetTypes();
            }
        }

        public void SetGeneration()
        {
            if(nationalDexNum == null)
            {
                generation = 0;
            }
            else if (int.Parse(nationalDexNum) <= 151)
            {
                generation = 1;
            }
            else if (int.Parse(nationalDexNum) <= 251)
            {
                generation = 2;
            }
            else if (int.Parse(nationalDexNum) <= 386)
            {
                generation = 3;
            }
            else if (int.Parse(nationalDexNum) <= 493)
            {
                generation = 4;
            }
            else if (int.Parse(nationalDexNum) <= 649)
            {
                generation = 5;
            }
            else if (int.Parse(nationalDexNum) <= 721)
            {
                generation = 6;
            }
            else if (int.Parse(nationalDexNum) <= 809)
            {
                generation = 7;
            }
            else if (int.Parse(nationalDexNum) <= 905)
            {
                generation = 8;
            }
            else if (int.Parse(nationalDexNum) <= 1010)
            {
                generation = 9;
            }
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
        public void UpdateIVs(int index, int value)
        {
            if (value >= 1 && value <= 31)
            {
                IV[index] = value;
            }
        }

    }
}
