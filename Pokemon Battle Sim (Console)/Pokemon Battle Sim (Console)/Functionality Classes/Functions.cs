using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using Pokemon_Battle_Sim__Console_.Functionality_Classes;

namespace Pokemon_Battle_Sim__Console_
{
    public class Functions
    {
        public static List<PType> allTypes { get; private set; }
        public static List<Pokemon> allPokemon { get; private set; }
        public static List<Move> allMoves { get; private set; }
        public static string[,] BurnInflictors;
        public static string[,] ParalysisInflictors;
        public static string[,] SleepInflictors;
        public static string[,] ConfusionInflictors;
        public static string[,] FrozenInflictors;
        public static string[,] PoisonInflictors;
        public string[] Natures = new string[25] { "Hardy", "Lonely", "Adamant", "Naughty", "Brave", "Bold", "Docile", "Impish", "Lax", "Relaxed", "Modest", "Mild", "Bashful", "Rash", "Quiet", "Calm", "Gentle", "Careful", "Quirky", "Sassy", "Timid", "Hasty", "Jolly", "Naive", "Serious" }; 
        public List<Move> GennedMoves = new List<Move>();
        public List<string> CheckedMoves = new List<string>();
        public static Random Rand = new Random();

        public static void LoadClassData()
        {
            allTypes = FileHandler.LoadJsonTypeData();
            allPokemon = FileHandler.LoadJsonClassData();
            allMoves = FileHandler.LoadJsonMoveData();
            foreach(Pokemon pokemon in allPokemon)
            {
                pokemon.SetTypes();
            }
        }
        
        public static void LoadTypeData()
        {
            allTypes = FileHandler.LoadJsonTypeData();
        }
        
        

        public void CheckStatusUse(string MoveEffect)
        {
            string[] Words = MoveEffect.Split(' ');
            string prev;
            foreach (string w in Words)
            {
                prev = w;
                switch (w)
                {
                    case "raises":
                        //set bool raises to true
                        Console.WriteLine("raises");
                        break;

                    case "lowers":
                        //set bool raises to false
                        Console.WriteLine("lowers");
                        break;

                    case "user's":
                        //set bool user to true
                        Console.WriteLine("users");
                        break;

                    case "target's":
                        //set bool user to false
                        Console.WriteLine("target");
                        break;

                    case "Attack":
                        if (prev == "Special")
                        {
                            //set bool SpAtk to true
                            Console.WriteLine("special attack");
                        }
                        else
                        {
                            //set bool attack to true
                            Console.WriteLine("attack");
                        }
                        break;

                    case "Defense":
                        if (prev == "Special")
                        {
                            //set bool SpAtk to false
                            Console.WriteLine("special defense");
                        }
                        else
                        {
                            //set bool attack to false
                            Console.WriteLine("defense");
                        }
                        break;

                    case "Speed":
                        //set bool speed to true
                        Console.WriteLine("speed");
                        break;

                    case "one":
                        //set int/multiplier to +1
                        Console.WriteLine(1);
                        break;

                    case "two":
                        //set int/multiplier to +2
                        Console.WriteLine(2);
                        break;

                    case "three":
                        //set int/multiplier to +3
                        Console.WriteLine(3);
                        break;

                    case "four":
                        //set int/multiplier to +4
                        Console.WriteLine(4);
                        break;

                    case "five":
                        //set int/multiplier to +5
                        Console.WriteLine(5);
                        break;
                }
            }
        }

        public ActivePokemon SwitchPokemon(List<ActivePokemon> T, ActivePokemon P, int S)
        {
            for (int i = 0; i < T.Count; i++)
            {
                if (T[i].Name == P.Name)
                {
                    T[i] = P;
                }
            }
            return T[S];
        }
        public void SetInflictors()
        {
            BurnInflictors = WebScraper.GetBurnInflictors();
            ParalysisInflictors = WebScraper.GetParalysisInflictors();
            SleepInflictors = WebScraper.GetSleepInflictors();
            ConfusionInflictors = WebScraper.GetConfusionInflictors();
            FrozenInflictors = WebScraper.GetSleepInflictors();
            PoisonInflictors = WebScraper.GetPoisonInflictors();
        }
        public string SplitPercentage(string text)
        {
            string num = " ";
            foreach (char c in text)
            {
                switch (c)
                {
                    case '1':
                        num = "1";
                        break;

                    case '2':
                        num = "2";
                        break;

                    case '3':
                        num = "3";
                        break;

                    case '4':
                        num = "4";
                        break;

                    case '5':
                        num = "5";
                        break;

                }
            }
            text = text.Substring(text.IndexOf(num));
            text = text.Substring(0, text.IndexOf("%"));
            return text;
        }
        public string[] SplitRegion(string Pokemon)
        {
            bool space = false;
            foreach (char c in Pokemon)
            {
                if (c == ' ')
                {
                    space = true;
                }
            }

            if (space == true)
            {
                string[] words = Pokemon.Split(' ');
                return words;
            }
            return null;
        }

        public void SetStatus(ActivePokemon P2, Move M)
        {
            float StatusChance = Rand.Next(0, 100);

            for (int i = 0; i < BurnInflictors.GetLength(0); i++)
            {
                if (BurnInflictors[i, 0] == M.Name)
                {
                    if (StatusChance < int.Parse(BurnInflictors[i, 1]))
                    {
                        P2.OnFire = true;
                        return;
                    }
                }
            }

            for (int i = 0; i < ParalysisInflictors.GetLength(0); i++)
            {
                if (ParalysisInflictors[i, 0] == M.Name)
                {
                    if (StatusChance < int.Parse(ParalysisInflictors[i, 1]))
                    {
                        P2.Paralysed = true;
                        return;
                    }
                }
            }

            for (int i = 0; i < SleepInflictors.GetLength(0); i++)
            {
                if (SleepInflictors[i, 0] == M.Name)
                {
                    if (StatusChance < int.Parse(SleepInflictors[i, 1]))
                    {
                        P2.Asleep = true;
                        return;
                    }
                }
            }

            for (int i = 0; i < ConfusionInflictors.GetLength(0); i++)
            {
                if (ConfusionInflictors[i, 0] == M.Name)
                {
                    if (StatusChance < int.Parse(ConfusionInflictors[i, 1]))
                    {
                        P2.Confused = true;
                        return;
                    }
                }
            }

            for (int i = 0; i < FrozenInflictors.GetLength(0); i++)
            {
                if (FrozenInflictors[i, 0] == M.Name)
                {
                    if (StatusChance < int.Parse(FrozenInflictors[i, 1]))
                    {
                        P2.Frozen = true;
                        return;
                    }
                }
            }

            for (int i = 0; i < PoisonInflictors.GetLength(0); i++)
            {
                if (PoisonInflictors[i, 0] == M.Name)
                {
                    if (StatusChance < int.Parse(PoisonInflictors[i, 1]))
                    {
                        P2.Poisoned = true;
                        return;
                    }
                }
            }
        }
        public void UseMove(ActivePokemon P, ActivePokemon P2, Move M, float Weather)
        {
            int hitchance = Rand.Next(0, 100);
            string identity = P.Name;
            if (P.Nickname != null)
            {
                identity = P.Nickname;
            }
            if (M.Accuracy != 100)
            {
                if (hitchance <= M.Accuracy)
                {
                    Console.WriteLine($"{identity} used {M.Name}");
                    Console.WriteLine("It missed!");
                    return;//attack missed so the function is called off
                }
            }
            int Attack = 0;
            int Defense = 0;

            switch (M.AttackType)
            {
                case "Physical":
                    Attack = P.ReturnStat(1);
                    Defense = P.ReturnStat(2);
                    break;

                case "Special":
                    Attack = P.ReturnStat(3);
                    Defense = P.ReturnStat(4);
                    break;

                case "Status":
                    SetStatus(P2, M);
                    break;
            }

            float CriticalMultiplier = 1;
            if (Rand.Next(0, 100) < 5) //4% chance for crit, 12.5% if move has high crit ratio - will be implemented later on
            {
                CriticalMultiplier = 1.5f;
            }
            float RandomRange = (float)(Math.Round((Rand.NextDouble() * (15) + 85)) / 100);
            float STAB = 1;
            if (P.Type1 == M.Type || P.Type2 == M.Type)
            {
                STAB = 1.5f;
            }
            float typeeffectiveness = TypeEffectiveness(M.Type, P2.Type1, P2.Type2);
            float burn = 1;
            if (P.OnFire == true)
            {
                burn = 0.5f;
            }
            int damage = DamageCalc(P.Level, M.BaseDamage, Attack, Defense, Weather, CriticalMultiplier, STAB, RandomRange, typeeffectiveness, burn, 1);
            string effectiveness = "";
            switch (typeeffectiveness)
            {
                case 2:
                    effectiveness = "was Super Effective!";
                    break;
                case 4:
                    effectiveness = "was Super Effective!";
                    break;
                case 0.5f:
                    effectiveness = "was Not very Effective";
                    break;
                case 0:
                    effectiveness = "had No Effect";
                    break;
            }
            SetStatus(P2, M);
            M.DecreasePP();
            Console.WriteLine($"{identity} used {M.Name}");
            if (effectiveness != "")
            {
                Console.WriteLine($"It {effectiveness}");
            }
            P2.HP = P2.HP - damage;
        }
        public static ActivePokemon ConvertToActive(Pokemon P)
        {
            return new ActivePokemon(P.Name, P.Nickname, P.Gender, P.Level, P.Shiny, P.Helditem, P.BaseStats, new List<string>(), P.possibleMoves, P.IV, P.EV, P.Type1, P.Type2, P.Nature, P.Moveset);
        }

        public ActivePokemon[] ConvertToActive(Pokemon[] P)
        {
            ActivePokemon[] P2 = new ActivePokemon[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                P2[i] = ConvertToActive(P[i]);
            }
            return P2;
        }

        
        public int ArrayCount(Pokemon[] Array)
        {
            int count = 0;
            foreach (Pokemon p in Array)
            {
                if (p != null)
                    count++;
            }
            return count;
        }

        /* Obsolete Import/Export Methods
         * public string ValidateTeamImport(string[] Team)
        {
            string TeamName = Team[0].Substring(Team[0].IndexOf(":") + 1);
            Team T = new Team(TeamName);
            Pokemon[] P = T.ReturnList();
            int x = 4;
            for (int i = 0; i < 6; i++, x += 13)
            {
                List<string> PokemonFile = new List<string>();
                for (int y = x; y < x + 10; y++)
                {
                    PokemonFile.Add(Team[y]);
                }
                if (ValidatePokemonImport(PokemonFile.ToArray()) == "Successful")
                {
                    P[i] = ImportPokemon(PokemonFile.ToArray());
                }
                else
                {
                    return $"Error found in Pokemon {i}: {ValidatePokemonImport(PokemonFile.ToArray())}";
                }
            }
            return "Successful";
        }
        
        public string ValidatePokemonImport(string[] Pokemon)
        {
            string Nickname = Pokemon[0].Substring(0, Pokemon[0].IndexOf("("));
            string Name = Pokemon[0].Substring(Pokemon[0].IndexOf("(") + 1, Pokemon[0].IndexOf(")") - 1).Trim();
            Name = Name.Substring(0, Name.IndexOf(")"));
            string T1Name = WebScraper.GetType1Name(Name);
            if (FindType(T1Name) == null)
            {
                return "Pokemon not found";
            }
            PType T1 = FindType(T1Name);
            PType T2 = FindType(WebScraper.GetType2Name(Name));
            int[] B = WebScraper.GetBaseStats(Name).ToArray();
            string Gender;
            if (Pokemon[0].Substring(Pokemon[0].IndexOf("[") + 1, 1) == "]")
            {
                Gender = "N";
            }
            else
            {
                Gender = Pokemon[0].Substring(Pokemon[0].IndexOf("[") + 1, 1);
            }
            string ItemName = Pokemon[0].Substring(Pokemon[0].IndexOf("@") + 1, Pokemon[0].Length - Pokemon[0].IndexOf("@") - 1);
            Item Item = new Item(ItemName, "...", 0.5f);
            string AbilityName = (Pokemon[1].Substring(Pokemon[1].IndexOf(":") + 2));
            Ability Ability = new Ability(AbilityName, "...");
            int Level;
            if (Int32.TryParse(Pokemon[2].Substring(Pokemon[2].IndexOf(":") + 1).Trim(), out Level) == false)
            {
                return "Level input not in correct format";
            }
            if (Level > 100 || Level < 0)
            {
                return "Level out of range";
            }
            string temp = Pokemon[3];
            int SpeEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int SpDEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int SpAEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int DefEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int AtkEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int HPEV = int.Parse(temp.Substring(temp.IndexOf("P") + 1).Trim());
            if (SpeEV + SpDEV + SpAEV + DefEV + AtkEV + HPEV > 510)
            {
                return "Ev values too high";
            }
            int[] EVs = new int[6] { HPEV, AtkEV, DefEV, SpAEV, SpDEV, SpeEV };
            string Nature = (Pokemon[4].Substring(Pokemon[4].IndexOf(":") + 1).Trim());
            bool Shiny = false;
            if (Pokemon[5].Substring(Pokemon[5].IndexOf(":") + 1).Trim() == "Yes")
            {
                Shiny = true;
            }
            List<Move> Moveset = new List<Move>();
            for (int i = 6; i < 10; i++)
            {
                if (WebScraper.GetMove(Pokemon[i].Substring(Pokemon[i].IndexOf("-") + 1).Trim()) != null)
                {
                    Moveset.Add(WebScraper.GetMove(Pokemon[i].Substring(Pokemon[i].IndexOf("-") + 1).Trim()));
                }
                else
                {
                    return $"Move {i - 5} is not a real move";
                }

            }

            Pokemon p = new Pokemon(Name, T1, T2, B, new List<string>()); //empty list for moveset sort later
            p.Nickname = Nickname;
            p.Gender = Gender;
            p.Helditem = Item;
            p.Ability = Ability;
            p.Level = Level;
            p.EV = EVs;
            p.Nature = Nature;
            p.Shiny = Shiny;
            p.Moveset = Moveset;
            return "Successful";
        }
        public Team ImportTeam(string[] Team)
        {
            string TeamName = Team[0].Substring(Team[0].IndexOf(":") + 1);
            Team T = new Team(TeamName);
            Pokemon[] P = T.ReturnList();
            int x = 4;
            int y = 0;
            for (int i = 0; i < 6; i++, x = y + 3)
            {
                if (x >= Team.Length)
                {
                    break;
                }
                List<string> PokemonFile = new List<string>();
                y = x;
                while (Team[y] != " " && Team[y] != null)
                {
                    PokemonFile.Add(Team[y]);
                    if (y < Team.Length - 1)
                    {
                        y++;
                    }
                    else
                    {
                        break;
                    }
                }
                P[i] = ImportPokemon(PokemonFile.ToArray());
            }
            T.SetList(ConvertToActive(P));
            return T;
        }
        public Pokemon ImportPokemon(string[] Pokemon)
        {
            string Nickname = Pokemon[0].Substring(0, Pokemon[0].IndexOf("(")).Trim();
            string Name = Pokemon[0].Substring(Pokemon[0].IndexOf("(") + 1);
            Name = Name.Substring(0, Name.IndexOf(")"));
            PType T1 = FindType(WebScraper.GetType1Name(Name));
            PType T2 = FindType(WebScraper.GetType2Name(Name));
            int[] B = WebScraper.GetBaseStats(Name).ToArray();
            string Gender = Pokemon[0].Substring(Pokemon[0].IndexOf("[") + 1, 1);
            string ItemName = Pokemon[0].Substring(Pokemon[0].IndexOf("@") + 1, Pokemon[0].Length - Pokemon[0].IndexOf("@") - 1);
            Item Item = new Item(ItemName, "...", 0.5f);
            string AbilityName = (Pokemon[1].Substring(Pokemon[1].IndexOf(":") + 2));
            Ability Ability = new Ability(AbilityName, "...");
            int Level = int.Parse(Pokemon[2].Substring(Pokemon[2].IndexOf(":") + 1).Trim());
            string temp = Pokemon[3];
            int SpeEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int SpDEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int SpAEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int DefEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int AtkEV = int.Parse(temp.Substring(temp.LastIndexOf("/") + 5).Trim());
            temp = temp.Substring(0, temp.LastIndexOf("/"));
            int HPEV = int.Parse(temp.Substring(temp.IndexOf("P") + 1).Trim());
            int[] EVs = new int[6] { HPEV, AtkEV, DefEV, SpAEV, SpDEV, SpeEV };
            string Nature = (Pokemon[4].Substring(Pokemon[4].IndexOf(":") + 1).Trim());
            bool Shiny = false;

            if (Pokemon[5].Substring(Pokemon[5].IndexOf(":") + 1).Trim() == "Yes")
            {
                Shiny = true;
            }
            List<Move> Moveset = new List<Move>();
            int i = 6;
            while (Pokemon[i] != " " && Pokemon[i] != null)
            {
                int MoveIndex = MoveSearch(Pokemon[i].Substring(Pokemon[i].IndexOf("-") + 1).Trim());
                if (MoveIndex != -1)
                {
                    Moveset.Add(GennedMoves[MoveIndex]);
                }
                else
                {
                    Move tempmove = WebScraper.GetMove(Pokemon[i].Substring(Pokemon[i].IndexOf("-") + 1).Trim());
                    Moveset.Add(tempmove);
                    GennedMoves.Add(tempmove);
                }
                if (i < Pokemon.Length - 1)
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            Pokemon p = new Pokemon(Name, T1, T2, B, new List<string>()); //list string for moveset sort later
            p.Nickname = Nickname;
            p.Gender = Gender;
            p.Helditem = Item;
            p.Ability = Ability;
            p.Level = Level;
            p.EV = EVs;
            p.Nature = Nature;
            p.Shiny = Shiny;
            p.Moveset = Moveset;
            return p;
        }

        public string[] ExportTeam(Team Team)
        {
            TextStore Store = new TextStore();
            string[] Text = new string[100];
            Text[0] = Store.MakeTeamLine(Team.ReturnTeamName());
            Text[1] = Store.SpaceLine;
            Text[2] = Store.TeamSeparator;
            Text[3] = Store.SpaceLine;

            int index = 4;
            int counter = 1;
            foreach (Pokemon p in Team.ReturnList())
            {
                if (p != null)
                {
                    string[] Pokemondata = ExportPokemon(p);
                    Array.Copy(Pokemondata, 0, Text, index, Pokemondata.Length);
                    index = index + 10;
                    if (counter < ArrayCount(Team.ReturnList()))
                    {
                        Text[index + 1] = Store.SpaceLine;
                        Text[index + 2] = Store.PKMNSeparator;
                        Text[index + 3] = Store.SpaceLine;
                        index = index + 4;
                    }
                    counter++;
                }
            }
            int arraysize = 0;
            foreach (string s in Text)
            {
                if (s != null)
                {
                    arraysize++;
                }
            }

            string[] SetText = new string[arraysize];
            int counterr = 0;
            foreach (string s in Text)
            {
                if (s != null)
                {
                    SetText[counterr] = s;
                    counterr++;
                }
            }
            return SetText;
        }

       

        public string[] ExportPokemon(Pokemon Pokemon)
        {
            TextStore Store = new TextStore();
            string[] Text = new string[10];

            Text[0] = Store.MakePokemonLine(Pokemon.Nickname, Pokemon.Name, Pokemon.Gender, Pokemon.Helditem);
            if (Pokemon.Ability != null)
            {
                Text[1] = Store.MakeAbilityLine(Pokemon.Ability.ReturnName());
            }
            else
            {
                Text[1] = Store.MakeAbilityLine(" ");
            }
            Text[2] = Store.MakeLevelLine(Pokemon.Level);
            Text[3] = Store.MakeEVLine(Pokemon.EV);
            Text[4] = Store.MakeNatureLine(Pokemon.Nature);
            Text[5] = Store.MakeShinyLine(Pokemon.Shiny);
            for (int i = 6; i < Pokemon.Moveset.Count + 6; i++)
            {
                Text[i] = Store.MakeMoveLine(Pokemon.Moveset[i - 6]);
            }

            return Text;
        }
        public bool GenTypes()
        {
            List<string> WaterWeaknesses = new List<string>() { "Grass", "Electric" };
            List<string> WaterResistances = new List<string>() { "Steel", "Fire", "Water", "Ice" };
            PType Water = new PType("Water", WaterWeaknesses, WaterResistances);
            TypeArray[0] = Water;

            List<string> FireWeaknesses = new List<string>() { "Water", "Ground", "Rock" };
            List<string> FireResistances = new List<string>() { "Bug", "Steel", "Fire", "Grass", "Ice" };
            PType Fire = new PType("Fire", FireWeaknesses, FireResistances);
            TypeArray[1] = Fire;

            List<string> GrassWeaknesses = new List<string>() { "Flying", "Poison", "Bug", "Fire", "Ice" };
            List<string> GrassResistances = new List<string>() { "Ground", "Water", "Grass", "Electric" };
            PType Grass = new PType("Grass", GrassWeaknesses, GrassResistances);
            TypeArray[2] = Grass;

            List<string> SteelWeaknesses = new List<string>() { "Fighting", "Ground", "Fire" };
            List<string> SteelResistances = new List<string>() { "Normal", "Flying", "Rock", "Bug", "Steel", "Grass", "Psychic", "Ice", "Dragon", "Fairy" };
            List<string> SteelImmunities = new List<string>() { "Poison" };
            PType Steel = new PType("Steel", SteelWeaknesses, SteelResistances, SteelImmunities);
            TypeArray[3] = Steel;

            List<string> FlyingWeaknesses = new List<string>() { "Rock", "Electric", "Ice" };
            List<string> FlyingResistances = new List<string>() { "Fighting", "Bug", "Grass" };
            List<string> FlyingImmunities = new List<string>() { "Ground" };
            PType Flying = new PType("Flying", FlyingWeaknesses, FlyingResistances, FlyingImmunities);
            TypeArray[4] = Flying;

            List<string> FightingWeaknesses = new List<string>() { "Flying", "Psychic", "Fairy" };
            List<string> FightingResistances = new List<string>() { "Rock", "Bug", "Dark" };
            PType Fighting = new PType("Fighting", FightingWeaknesses, FightingResistances);
            TypeArray[5] = Fighting;

            List<string> FairyWeaknesses = new List<string>() { "Poison", "Steel" };
            List<string> FairyResistances = new List<string>() { "Fighting", "Bug", "Dark" };
            List<string> FairyImmunities = new List<string>() { "Dragon" };
            PType Fairy = new PType("Fairy", FairyWeaknesses, FairyResistances, FairyImmunities);
            TypeArray[6] = Fairy;

            List<string> DragonWeaknesses = new List<string>() { "Ice", "Dragon", "Fairy" };
            List<string> DragonResistances = new List<string>() { "Fire", "Water", "Grass", "Electric" };
            PType Dragon = new PType("Dragon", DragonWeaknesses, DragonResistances);
            TypeArray[7] = Dragon;

            List<string> PoisonWeaknesses = new List<string>() { "Ground", "Psychic" };
            List<string> PoisonResistances = new List<string>() { "Fighting", "Poison", "Grass", "Fairy" };
            PType Poison = new PType("Poison", PoisonWeaknesses, PoisonResistances);
            TypeArray[8] = Poison;

            List<string> PsychicWeaknesses = new List<string>() { "Bug", "Ghost", "Dark" };
            List<string> PsychicResistances = new List<string>() { "Fighting", "Psychic" };
            PType Psychic = new PType("Psychic", PsychicWeaknesses, PsychicResistances);
            TypeArray[9] = Psychic;

            List<string> RockWeaknesses = new List<string>() { "Fighting", "Ground", "Steel", "Water", "Grass" };
            List<string> RockResistances = new List<string>() { "Normal", "Flying", "Poison", "Fire" };
            PType Rock = new PType("Rock", RockWeaknesses, RockResistances);
            TypeArray[10] = Rock;

            List<string> GroundWeaknesses = new List<string>() { "Water", "Grass", "Ice" };
            List<string> GroundResistances = new List<string>() { "Poison", "Rock" };
            List<string> GroundImmunities = new List<string>() { "Electric" };
            PType Ground = new PType("Ground", GroundWeaknesses, GroundResistances, GroundImmunities);
            TypeArray[11] = Ground;

            List<string> ElectricWeaknesses = new List<string>() { "Ground" };
            List<string> ElectricResistances = new List<string>() { "Flying", "Steel", "Electric" };
            PType Electric = new PType("Electric", ElectricWeaknesses, ElectricResistances);
            TypeArray[12] = Electric;

            List<string> NormalWeaknesses = new List<string>() { "Fighting" };
            List<string> NormalResistances = new List<string>();
            List<string> NormalImmunities = new List<string>() { "Ghost" };
            PType Normal = new PType("Normal", NormalWeaknesses, NormalResistances, NormalImmunities);
            TypeArray[13] = Normal;

            List<string> IceWeaknesses = new List<string>() { "Fighting", "Rock", "Steel", "Fire" };
            List<string> IceResistances = new List<string>() { "Ice" };
            PType Ice = new PType("Ice", IceWeaknesses, IceResistances);
            TypeArray[14] = Ice;

            List<string> BugWeaknesses = new List<string>() { "Flying", "Rock", "Fire" };
            List<string> BugResistances = new List<string>() { "Fighting", "Ground", "Grass" };
            PType Bug = new PType("Bug", BugWeaknesses, BugResistances);
            TypeArray[15] = Bug;

            List<string> DarkWeaknesses = new List<string>() { "Fighting", "Bug", "Fairy" };
            List<string> DarkResistances = new List<string>() { "Ghost", "Dark" };
            List<string> DarkImmunities = new List<string>() { "Psychic" };
            PType Dark = new PType("Dark", DarkWeaknesses, DarkResistances, DarkImmunities);
            TypeArray[16] = Dark;

            List<string> GhostWeaknesses = new List<string>() { "Ghost", "Dark" };
            List<string> GhostResistances = new List<string>() { "Poison", "Bug" };
            List<string> GhostImmunities = new List<string>() { "Normal", "Fighting" };
            PType Ghost = new PType("Ghost", GhostWeaknesses, GhostResistances, GhostImmunities);
            TypeArray[17] = Ghost;
            return true;
        }
        */

        public List<PType> GetTypes()
        {
            return allTypes;
        }

        public int MoveSearch(string MoveName)
        {
            for (int i = 0; i < GennedMoves.Count; i++)
            {
                if (GennedMoves[i].Name == MoveName)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool CheckedMoveSearch(string MoveName)
        {
            for (int i = 0; i < CheckedMoves.Count; i++)
            {
                if (CheckedMoves[i].ToLower() == MoveName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public string Hyphonator(string word)
        {
            bool space = false;
            int spacecount = 0;
            foreach (char c in word)
            {
                if (c == ' ')
                {
                    spacecount++;
                    space = true;
                }
            }
            if (space == true)
            {
                string empty = "";
                for (int i = 0; i < spacecount; i++)
                {
                    string f = word.Substring(0, word.IndexOf(" "));
                    empty += f + "-";
                    word = word.Substring(word.IndexOf(" ") + 1);
                    if (i == spacecount - 1)
                    {
                        empty += word;
                    }
                }
                word = empty;
            }
            return word;
        }

        public static string UpperStartingLetters(string word)
        {
            string[] words = word.Split(" ");
            string returnWord = "";
            foreach(string s in words)
            {
                returnWord += s[0].ToString().ToUpper();
                returnWord += s.Substring(1);
                returnWord += " ";
            }
            return returnWord;
        }

        public PType FindType(string T)
        {
            foreach (PType t in allTypes)
            {
                if (t != null)
                {
                    if (T.ToLower() == t.ReturnName().ToLower())
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        public Move FindMove(string M)
        {
            foreach (Move m in allMoves)
            {
                if (m != null)
                {
                    if (M.ToLower() == m.Name.ToLower())
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        

    }
}
