using System;
using HtmlAgilityPack;
using System.Collections.Generic;
class Program
{
    public static Functions fn = new Functions();
    public static Random Rand = new Random();
    static void Main(string[] args)
    {
        CreateRandomTeam();
    }
    public static void CreateRandomTeam()
    {
        Pokemon Stun = WebScraper.GetPokemon("StunFisk");
        Stun.Nickname = "Fisk";
        Stun.Nature = "Bold";
        Stun.AddMove("Iron Tail");
        Stun.AddMove("Body Slam");
        Stun.AddMove("Discharge");
        Stun.AddMove("Tackle");
        Stun.Shiny = true;
        Stun.Level = 50;
        Stun.Gender = "M";

        Pokemon Pawniard = WebScraper.GetPokemon("Pawniard");
        Pawniard.Nickname = "Pawn";
        Pawniard.Nature = "Adamant";
        Pawniard.AddMove("Dark pulse");
        Pawniard.AddMove("Night slash");
        Pawniard.AddMove("Tackle");
        Pawniard.AddMove("Swords dance");
        Pawniard.Shiny = false;
        Pawniard.Level = 100;

        Pokemon Alc = WebScraper.GetPokemon("Alcremie");
        Alc.Nickname = "Alc";
        Alc.Nature = "Timid";
        Alc.AddMove("Dazzling Gleam");
        Alc.AddMove("Fairy wind");
        Alc.AddMove("Mystical fire");
        Alc.AddMove("Slash");
        Alc.Shiny = true;
        Alc.Level = 20;
        Alc.Gender = "F";

        Pokemon Deox = WebScraper.GetPokemon("Deoxys");
        Deox.Nickname = "Deox";
        Deox.Nature = "Adamant";
        Deox.AddMove("Dazzling Gleam");
        Deox.AddMove("Extreme speed");
        Deox.AddMove("Hammer arm");
        Deox.AddMove("psychic");
        Deox.Shiny = true;
        Deox.Level = 47;
        Deox.Gender = "F";

        Pokemon Tep = WebScraper.GetPokemon("Tepig");
        Tep.Nickname = "Tep";
        Tep.Nature = "Adamant";
        Tep.AddMove("Quick attack");
        Tep.AddMove("Hammer arm");
        Tep.AddMove("Tackle");
        Tep.AddMove("Ember");
        Tep.Shiny = true;
        Tep.Level = 10;
        Tep.Gender = "M";

        Pokemon Char = WebScraper.GetPokemon("Charizard");
        Char.Nickname = "Char";
        Char.Nature = "Adamant";
        Char.AddMove("Quick attack");
        Char.AddMove("Dark pulse");
        Char.AddMove("Fly");
        Char.AddMove("Ember");
        Char.Shiny = true;
        Char.Level = 90;
        Char.Gender = "M";

        Team T = new Team("Random Pokemon");
        T.SetList(new Pokemon[] { Pawniard, Stun, Alc, Deox, Tep, Char });
        string[] Export = fn.ExportTeam(T);
        foreach (string s in Export)
        {
            Console.WriteLine(s);
        }
    }
}
static class WebScraper
{
    #region Inflictors
    public static string[,] GetBurnInflictors()
    {
        Functions fn = new Functions();
        string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
        string[,] Burn = new string[21, 2];
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        for (int index = 0; index < 21; index++)
        {
            Burn[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[1]/tbody/tr[{index + 1}]/td[1]").InnerText;
            string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[1]/tbody/tr[{index + 1}]/td[3]").InnerText;
            Burn[index, 1] = fn.SplitPercentage(text);
        }
        return Burn;
    }

    public static string[,] GetParalysisInflictors()
    {
        Functions fn = new Functions();
        string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
        string[,] Paralysis = new string[25, 2];
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        for (int index = 0; index < 24; index++)
        {
            if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[2]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(0, 1) != "G")
            {
                Paralysis[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[2]/tbody/tr[{index + 1}]/td[1]").InnerText;
                string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[2]/tbody/tr[{index + 1}]/td[3]").InnerText;
                Paralysis[index, 1] = fn.SplitPercentage(text);
            }
        }
        return Paralysis;
    }

    public static string[,] GetSleepInflictors()
    {
        Functions fn = new Functions();
        string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
        string[,] Sleep = new string[13, 2];
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        for (int index = 0; index < 12; index++)
        {
            if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(0, 1) != "G" && doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[1]").InnerText != "Rest")
            {
                Sleep[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[1]").InnerText;
                string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[3]").InnerText;
                Sleep[index, 1] = fn.SplitPercentage(text);
            }
        }
        return Sleep;
    }

    public static string[,] GetConfusionInflictors()
    {
        Functions fn = new Functions();
        string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
        string[,] Confusion = new string[16, 2];
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        for (int index = 0; index < 15; index++)
        {
            if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[4]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(0, 1) != "G")
            {
                Confusion[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[4]/tbody/tr[{index + 1}]/td[1]").InnerText;
                string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[4]/tbody/tr[{index + 1}]/td[3]").InnerText;
                Confusion[index, 1] = fn.SplitPercentage(text);
            }
        }
        return Confusion;
    }

    public static string[,] GetFrozenInflictors()
    {
        Functions fn = new Functions();
        string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
        string[,] Frozen = new string[9, 2];
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        for (int index = 0; index < 8; index++)
        {
            Frozen[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[5]/tbody/tr[{index + 1}]/td[1]").InnerText;
            string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[5]/tbody/tr[{index + 1}]/td[3]").InnerText;
            Frozen[index, 1] = fn.SplitPercentage(text);
        }
        return Frozen;
    }

    public static string[,] GetPoisonInflictors()
    {
        Functions fn = new Functions();
        string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
        string[,] Poison = new string[21, 2];
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        for (int index = 0; index < 20; index++)
        {
            if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[6]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(1, 1) != "-")
            {
                Poison[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[6]/tbody/tr[{index + 1}]/td[1]").InnerText;
                string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[6]/tbody/tr[{index + 1}]/td[3]").InnerText;
                Poison[index, 1] = fn.SplitPercentage(text);
            }
        }
        return Poison;
    }
    #endregion
    public static string GetPokemonImageRef(string PKMN)
    {
        Functions fn = new Functions();
        string baseurl = "https://www.serebii.net/pokemon/";
        string[] words = fn.SplitRegion(PKMN);
        string dexnum = "000";
        if (words != null)
        {
            PKMN = words[1];
            dexnum = GetDexNum(PKMN);
            string region = words[0];
            region = region.Substring(0, 1).ToLower();
            dexnum += $"-{region}";
        }
        else
        {
            dexnum = GetDexNum(PKMN);
        }
        string imageref = baseurl + $"art/{dexnum}.png";
        return imageref;

    }
    public static List<int> GetBaseStats(string PKMN)
    {
        string baseurl = "https://pokemondb.net/pokedex/";
        string url = baseurl + PKMN.ToLower();
        List<int> BaseStats = new List<int>();
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        var nodes = doc.DocumentNode.SelectNodes("/html/body/main/div[3]/div[2]/div/div[2]/div[1]/div[2]/table/tbody/tr[position()>0]");

        foreach (var node in nodes)
        {
            if (BaseStats.Count < 6)
            {
                BaseStats.Add(int.Parse(node.SelectSingleNode("td[1]").InnerText));
            }
        }
        return BaseStats;
    }

    public static string GetType1Name(string PKMN)
    {
        string baseurl = "https://pokemondb.net/pokedex/";
        string url = baseurl + PKMN.ToLower();
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("/html/body/main/div[3]/div[2]/div/div[1]/div[2]/table/tbody/tr[2]/td/a[1]");
        string TypeName = node.InnerText.ToString();
        return TypeName;
    }

    public static string GetType2Name(string PKMN)
    {
        string baseurl = "https://pokemondb.net/pokedex/";
        string url = baseurl + PKMN.ToLower();
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("/html/body/main/div[3]/div[2]/div/div[1]/div[2]/table/tbody/tr[2]/td/a[2]");
        if (node != null)
        {
            string TypeName = node.InnerText.ToString();
            return TypeName;
        }
        return "Pokemon has no Second Type";
    }

    public static Move GetMove(string move)
    {
        Functions fn = new Functions();
        move = fn.Hyphonator(move);
        int BaseDamage = 0;
        int Accuracy = 1;
        string baseurl = "https://pokemondb.net/move/";
        string url = baseurl + move.ToLower();
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[1]/td/a");
        string TypeName = node.InnerText.ToString().Trim();
        Type T;
        if (fn.FindType(TypeName) == null)
        {
            return null;
        }
        T = fn.FindType(TypeName);
        var node2 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[2]/td/text()");
        string TempAttackType = node2.InnerText.ToString();
        string AttackType = (TempAttackType.Substring(TempAttackType.IndexOf(" "))).Trim();
        var node3 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[3]/td");
        if (node3.InnerText.ToString() != "—")
        {
            BaseDamage = int.Parse(node3.InnerText.ToString());
        }

        var node4 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[5]/td/text()");
        string tempPP = (node4.InnerText.ToString());
        int PP = int.Parse(tempPP.Substring(0, tempPP.IndexOf(" ")));
        var node5 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[4]/td");
        if (node5.InnerText.ToString() != "∞" && node5.InnerText.ToString() != "—")
        {
            Accuracy = int.Parse(node5.InnerText.ToString());
        }


        var node7 = doc.DocumentNode.SelectSingleNode("/html/body/main/h1/text()");
        string moveName = node7.InnerText.ToString().Trim();
        var node6 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[2]/p/text()");
        string MoveInfo = moveName + " " + node6.InnerText.ToString().TrimStart();
        return new Move(moveName, T, MoveInfo, BaseDamage, AttackType, PP, Accuracy);
    }

    public static string GetDexNum(string PKMN)
    {
        Functions fn = new Functions();
        string baseurl = "https://pokemondb.net/pokedex/";
        string url = baseurl + PKMN.ToLower();
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("/html/body/main/div[3]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td/strong");
        string dexnum = node.InnerText;
        return dexnum;
    }

    public static Pokemon GetPokemon(string PKMN)
    {
        Functions fn = new Functions();
        string baseurl = "https://pokemondb.net/pokedex/";
        string url = baseurl + PKMN.ToLower();
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        var node = doc.DocumentNode.SelectSingleNode("/html/body/main/h1");
        if (node == null)
        {
            Console.WriteLine("Pokemon does not exist");
            return null;
        }

        Type T1 = fn.FindType(GetType1Name(PKMN));
        Type T2 = fn.FindType(GetType2Name(PKMN));
        int[] B = GetBaseStats(PKMN).ToArray();

        return new Pokemon(PKMN, T1, T2, B);

    }
}
public class Functions
{
    public bool gennedtypes = false;
    private static Type[] TypeArray = new Type[18];
    public static string[,] BurnInflictors;
    public static string[,] ParalysisInflictors;
    public static string[,] SleepInflictors;
    public static string[,] ConfusionInflictors;
    public static string[,] FrozenInflictors;
    public static string[,] PoisonInflictors;
    public string[] Natures = new string[25];
    public List<Move> GennedMoves = new List<Move>();
    public List<string> CheckedMoves = new List<string>();
    public static Random Rand = new Random();


    public string ValidateTeamImport(string[] Team)
    {
        Functions fn = new Functions();
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
            if (fn.ValidatePokemonImport(PokemonFile.ToArray()) == "Successful")
            {
                P[i] = fn.ImportPokemon(PokemonFile.ToArray());
            }
            else
            {
                return $"Error found in Pokemon {i}: {fn.ValidatePokemonImport(PokemonFile.ToArray())}";
            }
        }
        return "Successful";
    }
    public string ValidatePokemonImport(string[] Pokemon)
    {
        Functions fn = new Functions();
        string Nickname = Pokemon[0].Substring(0, Pokemon[0].IndexOf("("));
        string Name = Pokemon[0].Substring(Pokemon[0].IndexOf("(") + 1, Pokemon[0].IndexOf(")") - 1).Trim();
        Name = Name.Substring(0, Name.IndexOf(")"));
        string T1Name = WebScraper.GetType1Name(Name);
        if (fn.FindType(T1Name) == null)
        {
            return "Pokemon not found";
        }
        Type T1 = fn.FindType(T1Name);
        Type T2 = fn.FindType(WebScraper.GetType2Name(Name));
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
        Ability Ability = new Ability(AbilityName, "...", 1);
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

        Pokemon p = new Pokemon(Name, T1, T2, B);
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
            if (T[i].ReturnName() == P.ReturnName())
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
    public float TypeEffectiveness(Type Attack, Type T1, Type T2)
    {
        float TypeMultiplier = 1;
        switch (T2 == null)
        {
            case false:
                foreach (string weak in T1.ReturnWeaknesses())
                {
                    if (Attack.ReturnName() == weak)
                    {
                        TypeMultiplier *= 2;
                    }
                }
                foreach (string resist in T1.ReturnResistances())
                {
                    if (Attack.ReturnName() == resist)
                    {
                        TypeMultiplier /= 2;
                    }
                }
                if (T1.ReturnImmunities() != null)
                {
                    foreach (string immune in T1.ReturnImmunities())
                    {
                        if (Attack.ReturnName() == immune)
                        {
                            TypeMultiplier = 0;
                        }
                    }
                }
                foreach (string weak in T2.ReturnWeaknesses())
                {
                    if (Attack.ReturnName() == weak)
                    {
                        TypeMultiplier *= 2;
                    }
                }
                foreach (string resist in T2.ReturnResistances())
                {
                    if (Attack.ReturnName() == resist)
                    {
                        TypeMultiplier /= 2;
                    }
                }
                if (T2.ReturnImmunities() != null)
                {
                    foreach (string immune in T2.ReturnImmunities())
                    {
                        if (Attack.ReturnName() == immune)
                        {
                            TypeMultiplier = 0;
                        }
                    }
                }

                break;

            case true:
                foreach (string weak in T1.ReturnWeaknesses())
                {
                    if (Attack.ReturnName() == weak)
                    {
                        TypeMultiplier *= 2;
                    }
                }
                foreach (string resist in T1.ReturnResistances())
                {
                    if (Attack.ReturnName() == resist)
                    {
                        TypeMultiplier /= 2;
                    }
                }
                break;
        }
        return TypeMultiplier;
    }

    public void SetStatus(ActivePokemon P2, Move M)
    {
        float StatusChance = Rand.Next(0, 100);

        for (int i = 0; i < BurnInflictors.GetLength(0); i++)
        {
            if (BurnInflictors[i, 0] == M.ReturnName())
            {
                if (StatusChance < int.Parse(BurnInflictors[i, 1]))
                {
                    P2.OnFire = true;
                }
            }
        }

        for (int i = 0; i < ParalysisInflictors.GetLength(0); i++)
        {
            if (ParalysisInflictors[i, 0] == M.ReturnName())
            {
                if (StatusChance < int.Parse(ParalysisInflictors[i, 1]))
                {
                    P2.OnFire = true;
                }
            }
        }

        for (int i = 0; i < SleepInflictors.GetLength(0); i++)
        {
            if (SleepInflictors[i, 0] == M.ReturnName())
            {
                if (StatusChance < int.Parse(SleepInflictors[i, 1]))
                {
                    P2.OnFire = true;
                }
            }
        }

        for (int i = 0; i < ConfusionInflictors.GetLength(0); i++)
        {
            if (ConfusionInflictors[i, 0] == M.ReturnName())
            {
                if (StatusChance < int.Parse(ConfusionInflictors[i, 1]))
                {
                    P2.OnFire = true;
                }
            }
        }

        for (int i = 0; i < FrozenInflictors.GetLength(0); i++)
        {
            if (FrozenInflictors[i, 0] == M.ReturnName())
            {
                if (StatusChance < int.Parse(FrozenInflictors[i, 1]))
                {
                    P2.OnFire = true;
                }
            }
        }

        for (int i = 0; i < PoisonInflictors.GetLength(0); i++)
        {
            if (PoisonInflictors[i, 0] == M.ReturnName())
            {
                if (StatusChance < int.Parse(PoisonInflictors[i, 1]))
                {
                    P2.OnFire = true;
                }
            }
        }
    }
    public void UseMove(ActivePokemon P, ActivePokemon P2, Move M, float Weather)
    {
        int hitchance = Rand.Next(0, 100);
        string identity = P.ReturnName();
        if (P.Nickname != null)
        {
            identity = P.Nickname;
        }
        if (M.ReturnAccuracy() != 100)
        {
            if (hitchance <= M.ReturnAccuracy())
            {
                Console.WriteLine($"{identity} used {M.ReturnName()}");
                Console.WriteLine("It missed!");
                return;//attack missed so the function is called off
            }
        }
        int Attack = 0;
        int Defense = 0;

        switch (M.ReturnAttackType())
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
        if (P.ReturnType1() == M.ReturnType() || P.ReturnType2() == M.ReturnType())
        {
            STAB = 1.5f;
        }
        float typeeffectiveness = TypeEffectiveness(M.ReturnType(), P2.ReturnType1(), P2.ReturnType2());
        float burn = 1;
        if (P.OnFire == true)
        {
            burn = 0.5f;
        }
        int damage = DamageCalc(P.Level, M.ReturnBaseDamage(), Attack, Defense, Weather, CriticalMultiplier, STAB, RandomRange, typeeffectiveness, burn, 1);
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
        Console.WriteLine($"{identity} used {M.ReturnName()}");
        if (effectiveness != "")
        {
            Console.WriteLine($"It {effectiveness}");
        }
        P2.HP = P2.HP - damage;
    }
    public ActivePokemon ConvertToActive(Pokemon P)
    {
        return new ActivePokemon(P.ReturnName(), P.Nickname, P.Gender, P.Level, P.Shiny, P.Helditem, P.ReturnBaseStats(), P.IV, P.EV, P.ReturnType1(), P.ReturnType2(), P.Nature, P.Moveset);
    }

    public Team ImportTeam(string[] Team)
    {
        Functions fn = new Functions();
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
            P[i] = fn.ImportPokemon(PokemonFile.ToArray());
        }
        T.SetList(P);
        return T;
    }
    public Pokemon ImportPokemon(string[] Pokemon)
    {
        string Nickname = Pokemon[0].Substring(0, Pokemon[0].IndexOf("(")).Trim();
        string Name = Pokemon[0].Substring(Pokemon[0].IndexOf("(") + 1);
        Name = Name.Substring(0, Name.IndexOf(")"));
        Type T1 = FindType(WebScraper.GetType1Name(Name));
        Type T2 = FindType(WebScraper.GetType2Name(Name));
        int[] B = WebScraper.GetBaseStats(Name).ToArray();
        string Gender = Pokemon[0].Substring(Pokemon[0].IndexOf("[") + 1, 1);
        string ItemName = Pokemon[0].Substring(Pokemon[0].IndexOf("@") + 1, Pokemon[0].Length - Pokemon[0].IndexOf("@") - 1);
        Item Item = new Item(ItemName, "...", 0.5f);
        string AbilityName = (Pokemon[1].Substring(Pokemon[1].IndexOf(":") + 2));
        Ability Ability = new Ability(AbilityName, "...", 1);
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
        Pokemon p = new Pokemon(Name, T1, T2, B);
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

    public string[] ExportPokemon(Pokemon Pokemon)
    {
        TextStore Store = new TextStore();
        string[] Text = new string[10];

        Text[0] = Store.MakePokemonLine(Pokemon.Nickname, Pokemon.ReturnName(), Pokemon.Gender, Pokemon.Helditem);
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
        Type Water = new Type("Water", WaterWeaknesses, WaterResistances);
        TypeArray[0] = Water;

        List<string> FireWeaknesses = new List<string>() { "Water", "Ground", "Rock" };
        List<string> FireResistances = new List<string>() { "Bug", "Steel", "Fire", "Grass", "Ice" };
        Type Fire = new Type("Fire", FireWeaknesses, FireResistances);
        TypeArray[1] = Fire;

        List<string> GrassWeaknesses = new List<string>() { "Flying", "Poison", "Bug", "Fire", "Ice" };
        List<string> GrassResistances = new List<string>() { "Ground", "Water", "Grass", "Electric" };
        Type Grass = new Type("Grass", GrassWeaknesses, GrassResistances);
        TypeArray[2] = Grass;

        List<string> SteelWeaknesses = new List<string>() { "Fighting", "Ground", "Fire" };
        List<string> SteelResistances = new List<string>() { "Normal", "Flying", "Rock", "Bug", "Steel", "Grass", "Psychic", "Ice", "Dragon", "Fairy" };
        List<string> SteelImmunities = new List<string>() { "Poison" };
        Type Steel = new Type("Steel", SteelWeaknesses, SteelResistances, SteelImmunities);
        TypeArray[3] = Steel;

        List<string> FlyingWeaknesses = new List<string>() { "Rock", "Electric", "Ice" };
        List<string> FlyingResistances = new List<string>() { "Fighting", "Bug", "Grass" };
        List<string> FlyingImmunities = new List<string>() { "Ground" };
        Type Flying = new Type("Flying", FlyingWeaknesses, FlyingResistances, FlyingImmunities);
        TypeArray[4] = Flying;

        List<string> FightingWeaknesses = new List<string>() { "Flying", "Psychic", "Fairy" };
        List<string> FightingResistances = new List<string>() { "Rock", "Bug", "Dark" };
        Type Fighting = new Type("Fighting", FightingWeaknesses, FightingResistances);
        TypeArray[5] = Fighting;

        List<string> FairyWeaknesses = new List<string>() { "Poison", "Steel" };
        List<string> FairyResistances = new List<string>() { "Fighting", "Bug", "Dark" };
        List<string> FairyImmunities = new List<string>() { "Dragon" };
        Type Fairy = new Type("Fairy", FairyWeaknesses, FairyResistances, FairyImmunities);
        TypeArray[6] = Fairy;

        List<string> DragonWeaknesses = new List<string>() { "Ice", "Dragon", "Fairy" };
        List<string> DragonResistances = new List<string>() { "Fire", "Water", "Grass", "Electric" };
        Type Dragon = new Type("Dragon", DragonWeaknesses, DragonResistances);
        TypeArray[7] = Dragon;

        List<string> PoisonWeaknesses = new List<string>() { "Ground", "Psychic" };
        List<string> PoisonResistances = new List<string>() { "Fighting", "Poison", "Grass", "Fairy" };
        Type Poison = new Type("Poison", PoisonWeaknesses, PoisonResistances);
        TypeArray[8] = Poison;

        List<string> PsychicWeaknesses = new List<string>() { "Bug", "Ghost", "Dark" };
        List<string> PsychicResistances = new List<string>() { "Fighting", "Psychic" };
        Type Psychic = new Type("Psychic", PsychicWeaknesses, PsychicResistances);
        TypeArray[9] = Psychic;

        List<string> RockWeaknesses = new List<string>() { "Fighting", "Ground", "Steel", "Water", "Grass" };
        List<string> RockResistances = new List<string>() { "Normal", "Flying", "Poison", "Fire" };
        Type Rock = new Type("Rock", RockWeaknesses, RockResistances);
        TypeArray[10] = Rock;

        List<string> GroundWeaknesses = new List<string>() { "Water", "Grass", "Ice" };
        List<string> GroundResistances = new List<string>() { "Poison", "Rock" };
        List<string> GroundImmunities = new List<string>() { "Electric" };
        Type Ground = new Type("Ground", GroundWeaknesses, GroundResistances, GroundImmunities);
        TypeArray[11] = Ground;

        List<string> ElectricWeaknesses = new List<string>() { "Ground" };
        List<string> ElectricResistances = new List<string>() { "Flying", "Steel", "Electric" };
        Type Electric = new Type("Electric", ElectricWeaknesses, ElectricResistances);
        TypeArray[12] = Electric;

        List<string> NormalWeaknesses = new List<string>() { "Fighting" };
        List<string> NormalResistances = new List<string>();
        List<string> NormalImmunities = new List<string>() { "Ghost" };
        Type Normal = new Type("Normal", NormalWeaknesses, NormalResistances, NormalImmunities);
        TypeArray[13] = Normal;

        List<string> IceWeaknesses = new List<string>() { "Fighting", "Rock", "Steel", "Fire" };
        List<string> IceResistances = new List<string>() { "Ice" };
        Type Ice = new Type("Ice", IceWeaknesses, IceResistances);
        TypeArray[14] = Ice;

        List<string> BugWeaknesses = new List<string>() { "Flying", "Rock", "Fire" };
        List<string> BugResistances = new List<string>() { "Fighting", "Ground", "Grass" };
        Type Bug = new Type("Bug", BugWeaknesses, BugResistances);
        TypeArray[15] = Bug;

        List<string> DarkWeaknesses = new List<string>() { "Fighting", "Bug", "Fairy" };
        List<string> DarkResistances = new List<string>() { "Ghost", "Dark" };
        List<string> DarkImmunities = new List<string>() { "Psychic" };
        Type Dark = new Type("Dark", DarkWeaknesses, DarkResistances, DarkImmunities);
        TypeArray[16] = Dark;

        List<string> GhostWeaknesses = new List<string>() { "Ghost", "Dark" };
        List<string> GhostResistances = new List<string>() { "Poison", "Bug" };
        List<string> GhostImmunities = new List<string>() { "Normal", "Fighting" };
        Type Ghost = new Type("Ghost", GhostWeaknesses, GhostResistances, GhostImmunities);
        TypeArray[17] = Ghost;

        gennedtypes = true;
        return gennedtypes;
    }
    public void GenNatures()
    {
        Natures[0] = "Hardy";
        Natures[1] = "Lonely";
        Natures[2] = "Adamant";
        Natures[3] = "Naughty";
        Natures[4] = "Brave";
        Natures[5] = "Bold";
        Natures[6] = "Docile";
        Natures[7] = "Impish";
        Natures[8] = "Lax";
        Natures[9] = "Relaxed";
        Natures[10] = "Modest";
        Natures[11] = "Mild";
        Natures[12] = "Bashful";
        Natures[13] = "Rash";
        Natures[14] = "Quiet";
        Natures[15] = "Calm";
        Natures[16] = "Gentle";
        Natures[17] = "Careful";
        Natures[18] = "Quirky";
        Natures[19] = "Sassy";
        Natures[20] = "Timid";
        Natures[21] = "Hasty";
        Natures[22] = "Jolly";
        Natures[23] = "Naive";
        Natures[24] = "Serious";

    }

    public int MoveSearch(string MoveName)
    {
        for (int i = 0; i < GennedMoves.Count; i++)
        {
            if (GennedMoves[i].ReturnName() == MoveName)
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

    public Type FindType(string T)
    {
        foreach (Type t in TypeArray)
        {
            if (t != null)
            {
                if (T == t.ReturnName())
                {
                    return t;
                }
            }
        }
        return null;
    }

    public int DamageCalc(int Level, int BasePower, int Attack, int Defense, float WeatherMultiplier, float CriticalMultiplier, float STABMultiplier, float RandomRange, float Typeeffectiveness, float BurnModifier, float MiscModifier)
    {
        return (int)Math.Round((((((2 * Level) / 5) + 2) * BasePower * (Attack / Defense) / 50) + 2) * WeatherMultiplier * CriticalMultiplier * STABMultiplier * RandomRange * Typeeffectiveness * BurnModifier * MiscModifier);
    }
}
public class Type
{
    private string Name;
    private List<string> Weaknesses = new List<string>();
    private List<string> Resistances = new List<string>();
    private List<string> Immunities = new List<string>();

    public Type(string n, List<string> W, List<string> R)
    {
        Name = n;
        Weaknesses = W;
        Resistances = R;
    }
    public Type(string n, List<string> W, List<string> R, List<string> I)
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
    protected Type Type1;
    protected Type Type2;
    public string Nature;
    public List<Move> Moveset = new List<Move>();

    public Pokemon(string n, Type T1, Type T2, int[] B)
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

    public Type ReturnType1()
    {
        return Type1;
    }

    public Type ReturnType2()
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
    public ActivePokemon(string n, string nm, string g, int l, bool s, Item i, int[] b, int[] iv, int[] ev, Type T1, Type T2, string N, List<Move> M) : base(n, T1, T2, b)
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
public class Item
{
    private string Name;
    private string Info;
    private float DamageMultiplier = 0;
    private string ImageRef;

    public Item(string N, string I, float DM)
    {
        Name = N;
        Info = I;
        DamageMultiplier = DM;
    }

    public string ReturnName()
    {
        return Name;
    }
}
public class Move
{
    private string Name;
    private Type Type;
    private string Info;
    private int BaseDamage;
    private string AttackType;
    private int PP;
    private int Accuracy;

    public Move(string n, Type T, string I, int BD, string AT, int P, int a)
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

    public Type ReturnType()
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
public class Team
{
    private string TeamName;
    private Pokemon[] Pokemon;
    private Pokemon Slot1;
    private Pokemon Slot2;
    private Pokemon Slot3;
    private Pokemon Slot4;
    private Pokemon Slot5;
    private Pokemon Slot6;

    public Team(string t)
    {
        TeamName = t;
        Pokemon = new Pokemon[6];
        Pokemon[0] = Slot1;
        Pokemon[1] = Slot2;
        Pokemon[2] = Slot3;
        Pokemon[3] = Slot4;
        Pokemon[4] = Slot5;
        Pokemon[5] = Slot6;
    }

    public void EditPokemon(int slot)
    {
        Pokemon TempPokemon = Pokemon[slot - 1];
    }

    public Pokemon[] ReturnList()
    {
        return Pokemon;
    }

    public void SetList(Pokemon[] p)
    {
        Pokemon = p;
    }

    public string ReturnTeamName()
    {
        return TeamName;
    }
}
public class Ability
{
    private string Name;
    private string Info;
    private int Multiplier;

    public Ability(string n, string i, int m)
    {
        Name = n;
        Info = i;
        Multiplier = m;
    }

    public string ReturnName()
    {
        return Name;
    }
}
public class TextStore
{
    public string SpaceLine = " ";
    public string TeamSeparator = "~";
    public string PKMNSeparator = "#";
    public string MakeTeamLine(string TeamName)
    {
        return $"TeamName:{TeamName}";
    }

    public string MakePokemonLine(string NN, string N, string G, Item I)
    {
        string IN = "";
        if (I != null)
        {
            IN = I.ReturnName();
        }
        if (G == null)
        {
            G = "N";
        }

        return $"{NN} ({N}) [{G}] @{IN}";
    }

    public string MakeLevelLine(int Level)
    {
        return $"Level: {Level}";
    }

    public string MakeAbilityLine(string Ability)
    {
        return $"Ability: {Ability}";
    }

    public string MakeEVLine(int[] EV)
    {
        return $"EVs: HP {EV[0]} / Atk {EV[1]} / Def {EV[2]} / SpA {EV[3]} / SpD {EV[4]} / SpE {EV[5]}";
    }

    public string MakeNatureLine(string Nature)
    {
        return $"Nature: {Nature}";
    }

    public string MakeShinyLine(bool Shiny)
    {
        if (Shiny == true)
        {
            return "Shiny: Yes";
        }
        else
        {
            return "Shiny: No";
        }
    }

    public string MakeMoveLine(Move Move)
    {
        return $"- {Move.ReturnName()}";
    }
}
