using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Functionality_Classes
{
    internal static class FileHandler
    {
        public static void WriteToTxtFile()
        {
            var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonNames.txt");
            StreamWriter writer = new StreamWriter("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\PokemonClassData.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                Pokemon temp = WebScraper.GetPokemon(line);
                writer.WriteLine($"|{temp.nationalDexNum}|{temp.Name}|{temp.Type1.Name}|{(temp.Type2.Name != null ? temp.Type2.Name : " ")}|{temp.BaseStats[0]}|{temp.BaseStats[1]}|{temp.BaseStats[2]}|{temp.BaseStats[3]}|{temp.BaseStats[4]}|{temp.BaseStats[5]}|");
            }
            writer.Close();
        }

        public static void WritePokemonToJsonFile()
        {
            var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\Class Data\\PokemonNames.txt");
            List<Pokemon> allPokemon = new List<Pokemon>();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                allPokemon.Add(WebScraper.GetPokemon(line));
            }
            File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\PokemonClassData.json", JsonConvert.SerializeObject(allPokemon, Formatting.Indented));
        }

        public static void WritePokemonToJsonFile(List<Pokemon> allPokemon)
        {
            File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\PokemonClassData.json", JsonConvert.SerializeObject(allPokemon, Formatting.Indented));
        }

        public static void WriteMovesToJsonFile()
        {
            var lines = File.ReadLines("D:\\jackt\\Documents\\Pokemon-Project\\Pokemon Battle Sim (Console)\\Pokemon Battle Sim (Console)\\Class Data\\MoveNames.txt");
            List<Move> allMoves = new List<Move>();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                allMoves.Add(WebScraper.GetMove(line));
            }
            File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\MoveClassData.json", JsonConvert.SerializeObject(allMoves, Formatting.Indented));
        }

        public static void WriteTypesToJsonFile(List<PType> types)
        {
            File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\PokemonTypeData.json", JsonConvert.SerializeObject(types, Formatting.Indented));
        }

        public static void WriteAbilitiesToJsonFile()
        {
            File.WriteAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\PokemonAbilityData.json", JsonConvert.SerializeObject(WebScraper.GetAbilities(), Formatting.Indented));
        }

        public static List<Pokemon> LoadJsonClassData()
        {
            return JsonConvert.DeserializeObject<List<Pokemon>>(File.ReadAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\PokemonClassData.json"));
        }

        public static List<PType> LoadJsonTypeData()
        {
            return JsonConvert.DeserializeObject<List<PType>>(File.ReadAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\PokemonTypeData.json"));
        }

        public static List<Move> LoadJsonMoveData()
        {
            return JsonConvert.DeserializeObject<List<Move>>(File.ReadAllText(@"D:\jackt\Documents\Pokemon-Project\Pokemon Battle Sim (Console)\Pokemon Battle Sim (Console)\Class Data\MoveClassData.json"));
        }
    }
}
