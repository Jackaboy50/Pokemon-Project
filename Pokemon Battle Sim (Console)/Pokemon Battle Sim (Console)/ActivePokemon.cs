using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class ActivePokemon : Pokemon
    {
        public int HP;
        public int[] stats = new int[6];
        public bool Fainted = false;
        public bool Status = false;
        public bool OnFire = false;
        public bool Poisoned = false;
        public bool Frozen = false;
        public bool Paralysed = false;
        public bool Confused = false;
        public bool Asleep = false;
        public ActivePokemon(string n, string nm, string g, int l, bool s, Item i, int[] b, int[] iv, int[] ev, PType T1, PType T2, string N, List<Move> M) : base(n, T1, T2, b)
        {
            Nickname = nm;
            Gender = g;
            Level = l;
            Shiny = s;
            Helditem = i;
            BaseStats = b;
            IV = iv;
            EV = ev;
            Type1 = T1;
            Type2 = T2;
            Nature = N;
            Moveset = M;
            GenStats();
            HP = stats[0];
        }

        public void GenStats()
        {
            int[] BaseStats = ReturnBaseStats();
            stats[0] = (((2 * BaseStats[0] + IV[0] + (EV[0] / 4)) * Level) / 100) + Level + 10; //HP
            CalcStat(1); //Attack
            CalcStat(2); //Defense
            CalcStat(3); //Special Attack
            CalcStat(4); //Special Defense
            CalcStat(5); //Speed
        }

        public void CalcStat(int index)
        {
            int[] BaseStats = ReturnBaseStats();
            stats[index] = (int)Math.Round(((((2 * (BaseStats[index] + IV[index]) + (EV[index] / 4)) * Level) / 100) + 5) * GetNatureModifier(index));
        }

        public int ReturnStat(int index)
        {
            return stats[index];
        }

        public void DecreasePP(string Movename)
        {
            foreach (Move m in Moveset)
            {
                if (m.ReturnName() == Movename)
                {
                    m.DecreasePP();
                }
            }
        }

        public float GetNatureModifier(int index)
        {
            float Natmod = 1;
            switch (index)
            {
                case 1: //Attack
                    switch (Nature)
                    {
                        case "Lonely":
                            Natmod = 1.1F;
                            break;
                        case "Adamant":
                            Natmod = 1.1F;
                            break;
                        case "Naughty":
                            Natmod = 1.1F;
                            break;
                        case "Brave":
                            Natmod = 1.1F;
                            break;

                        case "Bold":
                            Natmod = 0.9F;
                            break;
                        case "Modest":
                            Natmod = 0.9F;
                            break;
                        case "Calm":
                            Natmod = 0.9F;
                            break;
                        case "Timid":
                            Natmod = 0.9F;
                            break;
                    }
                    break;
                case 2: //Defense
                    switch (Nature)
                    {
                        case "Bold":
                            Natmod = 1.1F;
                            break;
                        case "Impish":
                            Natmod = 1.1F;
                            break;
                        case "Lax":
                            Natmod = 1.1F;
                            break;
                        case "Relaxed":
                            Natmod = 1.1F;
                            break;

                        case "Lonely":
                            Natmod = 0.9F;
                            break;
                        case "Mild":
                            Natmod = 0.9F;
                            break;
                        case "Gentle":
                            Natmod = 0.9F;
                            break;
                        case "Hasty":
                            Natmod = 0.9F;
                            break;
                    }
                    break;
                case 3: //Special Attack
                    switch (Nature)
                    {
                        case "Modest":
                            Natmod = 1.1F;
                            break;
                        case "Mild":
                            Natmod = 1.1F;
                            break;
                        case "Rash":
                            Natmod = 1.1F;
                            break;
                        case "Quiet":
                            Natmod = 1.1F;
                            break;

                        case "Adamant":
                            Natmod = 0.9F;
                            break;
                        case "Impish":
                            Natmod = 0.9F;
                            break;
                        case "Careful":
                            Natmod = 0.9F;
                            break;
                        case "Jolly":
                            Natmod = 0.9F;
                            break;
                    }
                    break;
                case 4: //Special Defense
                    switch (Nature)
                    {
                        case "Calm":
                            Natmod = 1.1F;
                            break;
                        case "Gentle":
                            Natmod = 1.1F;
                            break;
                        case "Careful":
                            Natmod = 1.1F;
                            break;
                        case "Sassy":
                            Natmod = 1.1F;
                            break;

                        case "Naughty":
                            Natmod = 0.9F;
                            break;
                        case "Lax":
                            Natmod = 0.9F;
                            break;
                        case "Rash":
                            Natmod = 0.9F;
                            break;
                        case "Naive":
                            Natmod = 0.9F;
                            break;
                    }
                    break;
                case 5: //Speed
                    switch (Nature)
                    {
                        case "Timid":
                            Natmod = 1.1F;
                            break;
                        case "Hasty":
                            Natmod = 1.1F;
                            break;
                        case "Jolly":
                            Natmod = 1.1F;
                            break;
                        case "Naive":
                            Natmod = 1.1F;
                            break;

                        case "Brave":
                            Natmod = 0.9F;
                            break;
                        case "Relaxed":
                            Natmod = 0.9F;
                            break;
                        case "Quiet":
                            Natmod = 0.9F;
                            break;
                        case "Sassy":
                            Natmod = 0.9F;
                            break;
                    }
                    break;
            }

            return Natmod;
        }

    }
}
