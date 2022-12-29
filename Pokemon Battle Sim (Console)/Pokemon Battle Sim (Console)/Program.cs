using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using Pokemon_Battle_Sim__Console_;
using System.IO;

class Program
{
    public static Functions fn = new Functions();
    public static Random Rand = new Random();
    static void Main(string[] args)
    {
        fn.GenTypes();
        var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonNames.txt");
        StreamWriter writer = new StreamWriter("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonBaseStats.txt");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            Pokemon temp = WebScraper.GetPokemon(line);
            
            writer.WriteLine($"|{temp.ReturnName()}|{temp.ReturnType1().ReturnName()}|{(temp.ReturnType2() != null ? temp.ReturnType2().ReturnName() : " ")}|{temp.ReturnBaseStats()[0]}|{temp.ReturnBaseStats()[1]}|{temp.ReturnBaseStats()[2]}|{temp.ReturnBaseStats()[3]}|{temp.ReturnBaseStats()[4]}|{temp.ReturnBaseStats()[5]}|");
            
        }
        writer.Close();
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










