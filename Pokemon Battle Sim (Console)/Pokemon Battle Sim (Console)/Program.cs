using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using Pokemon_Battle_Sim__Console_;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;

class Program
{
    public static Functions fn = new Functions();
    public static Random Rand = new Random();
    public static List<Pokemon> allPokemon;
    static void Main(string[] args)
    {
        fn.GenTypes();
        WritePokemonToJsonFile();
    }

    public static void WriteToTxtFile()
    {
        var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonNames.txt");
        StreamWriter writer = new StreamWriter("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonClassData.txt");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            Pokemon temp = WebScraper.GetPokemon(line);
            writer.WriteLine($"|{temp.ReturnDexNum()}|{temp.ReturnName()}|{temp.ReturnType1()}|{(temp.ReturnType2() != null ? temp.ReturnType2() : " ")}|{temp.ReturnBaseStats()[0]}|{temp.ReturnBaseStats()[1]}|{temp.ReturnBaseStats()[2]}|{temp.ReturnBaseStats()[3]}|{temp.ReturnBaseStats()[4]}|{temp.ReturnBaseStats()[5]}|");
        }
        writer.Close();
    }

    public static void WritePokemonToJsonFile()
    {
        var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonNames.txt");
        List<Pokemon> allPokemon = new List<Pokemon>();
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            allPokemon.Add(WebScraper.GetPokemon(line));
        }
        File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\PokemonClassData.json", JsonConvert.SerializeObject(allPokemon, Formatting.Indented));
    }

    public static void WriteMovesToJsonFile()
    {
        var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\MoveNames.txt");
        List<Move> allMoves = new List<Move>();
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            allMoves.Add(WebScraper.GetMove(line));
        }
        File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\MoveClassData.json", JsonConvert.SerializeObject(allMoves, Formatting.Indented));
    }

    public static void LoadJsonClassData()
    {
        allPokemon = JsonConvert.DeserializeObject<List<Pokemon>>(File.ReadAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\PokemonClassData.json"));
    }
}