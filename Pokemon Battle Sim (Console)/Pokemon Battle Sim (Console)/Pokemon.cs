using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Pokemon
    {
        protected Functions fn = new Functions();
        private string ImageRef;
        private string DexNum;
        private string Name;
        public string Nickname; // assigned by the player, null by default
        public string Gender; //F , M or N for the respective genders
        public int Level = 1; // 1 - 100 dependent on ruleset
        public Ability Ability;
        public bool Shiny;
        public Item Helditem;
        protected int[] BaseStats = new int[6]; //Basestats should be webscraped and definite values
        public int[] IV = new int[6] { 1, 1, 1, 1, 1, 1 }; //IV's should be adjustable from 1 - 31 and they affect the base stats | in the order  HP , Atk , Def , SpA , SpD , SPe
        public int[] EV = new int[6] { 1, 1, 1, 1, 1, 1 }; //EV's will be inputted and adjusted by the player so this needs to be easily accessible | in the order  HP , Atk , Def , SpA , SpD , SPe
        protected PType Type1;
        protected PType Type2;
        public string Nature;
        public List<Move> Moveset = new List<Move>();

        public Pokemon(string n, PType T1, PType T2, int[] B)
        {
            Name = n;
            Type1 = T1;
            Type2 = T2;
            BaseStats = B;
            ImageRef = WebScraper.GetPokemonImageRef(Name);
            DexNum = WebScraper.GetDexNum(Name);
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
