﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    public class Move
    {
        private string Name;
        private PType Type;
        private string Info;
        private int BaseDamage;
        private string AttackType;
        private int PP;
        private int Accuracy;

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