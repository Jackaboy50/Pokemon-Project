using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Functionality_Classes
{
    internal static class BattleCalculator
    {
        public static int DamageCalc(int Level, int BasePower, int Attack, int Defense, float WeatherMultiplier, float CriticalMultiplier, float STABMultiplier, float RandomRange, float Typeeffectiveness, float BurnModifier, float MiscModifier)
        {
            return (int)Math.Round((((((2 * Level) / 5) + 2) * BasePower * (Attack / Defense) / 50) + 2) * WeatherMultiplier * CriticalMultiplier * STABMultiplier * RandomRange * Typeeffectiveness * BurnModifier * MiscModifier);
        }

        public static int BestMove(ActivePokemon attacker, ActivePokemon defender)
        {
            int bestDamage = 0;
            int index = 0;
            for(int i = 0; i < attacker.Moveset.Count; i++)
            {
                if(UseMove(attacker, defender, attacker.Moveset[i]) > bestDamage)
                {
                    index = i;
                    bestDamage = UseMove(attacker, defender, attacker.Moveset[i]);
                }
            }
            return index;
        }

        public static int UseMove(ActivePokemon attacker, ActivePokemon defender, Move move)
        {
            Random rand = new Random();
            return DamageCalc(
                attacker.Level, 
                move.BaseDamage, 
                attacker.stats[1], 
                defender.stats[2], 
                1f, 
                1f, 
                1f, 
                (float)(Math.Round((rand.NextDouble() * 15f) + 85f)) / 100f,
                TypeEffectiveness(move.Type, defender.Type1, defender.Type2), 
                1f, 
                1f);
        }

        public static float TypeEffectiveness(PType Attack, PType T1, PType T2)
        {
            float TypeMultiplier = 1;
            if(T2 != null)
            {
                if (T2.ReturnWeaknesses().Contains(Attack.Name))
                {
                    TypeMultiplier *= 2;
                }
                if (T2.ReturnResistances().Contains(Attack.Name))
                {
                    TypeMultiplier /= 2;
                }
                if (T2.ReturnImmunities() != null && T2.ReturnImmunities().Contains(Attack.Name))
                {
                    TypeMultiplier = 0;
                }
            }

            if (T1.ReturnWeaknesses().Contains(Attack.Name))
            {
                TypeMultiplier *= 2;
            }
            if (T1.ReturnResistances().Contains(Attack.Name))
            {
                TypeMultiplier /= 2;
            }
            if (T1.ReturnImmunities() != null && T1.ReturnImmunities().Contains(Attack.Name))
            {
                TypeMultiplier = 0;
            }
            return TypeMultiplier;
        }
    }
}
