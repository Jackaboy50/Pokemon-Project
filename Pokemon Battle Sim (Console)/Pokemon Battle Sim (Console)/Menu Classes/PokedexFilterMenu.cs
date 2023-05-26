using Pokemon_Battle_Sim__Console_.Functionality_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Menu_Classes
{
    internal static class PokedexFilterMenu
    {
        public static string SelectTypeFilter()
        {
            Console.Clear();
            Console.WriteLine("Enter a type, or enter exit to leave");
            string userChoice = Console.ReadLine().ToLower();
            Functions fn = new Functions();

            while (fn.FindType(userChoice) == null)
            {
                if(userChoice == "exit")
                {
                    return userChoice;
                }
                Console.WriteLine("Please enter a valid Pokemon type");
                Console.WriteLine("Would you like a list of all types? Y/N");
                if(UserInputHandler.UserYesOrNo() == "Y")
                {
                    Console.WriteLine();
                    foreach(PType type in fn.GetTypes())
                    {
                        Console.WriteLine(type.Name);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid Pokemon type");
                }
                userChoice = Console.ReadLine().ToLower();
            }
            return userChoice;
        }
        
        public static int SelectGenerationFilter()
        {
            Console.Clear();
            Console.WriteLine("Enter a Generation of Pokemon (1 - 9)");
            return UserInputHandler.GetUserIntegerInRange(1, 9);
        }

        public static string SelectMoveFilter()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of any move, or enter exit to leave");
            string userChoice = Console.ReadLine();
            Functions fn = new Functions();
            while (fn.FindMove(userChoice) == null)
            {
                if (userChoice == "exit")
                {
                    return "exit";
                }
                Console.WriteLine("Please enter a valid Pokemon move");
                Console.WriteLine("Would you like a list of all moves? Y/N");
                if (UserInputHandler.UserYesOrNo() == "Y")
                {
                    Console.WriteLine();
                    foreach (Move move in Functions.allMoves)
                    {
                        Console.WriteLine(move.Name);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid Pokemon move");
                }
                userChoice = Console.ReadLine().ToLower();
            }
            return userChoice;
        }

        public static string SelectGameFilter()
        {
            Console.Clear();
            Console.WriteLine("Choose a Pokemon Game from the list below");
            List<string> allGames = new List<string>()
            {
                "Red/Blue/Yellow",
                "Gold/Silver/Crystal",
                "Ruby/Sapphire/Emerald",
                "FireRed/LeafGreen",
                "Diamond/Pearl",
                "Platinum",
                "HeartGold/SoulSilver",
                "Black 2/White 2",
                "X/Y - Central Kalos",
                "Omega Ruby/Alpha Sapphire",
                "Sun/Moon - Alola dex",
                "U.Sun/U.Moon - Alola dex",
                "Let's Go Pikachu/Let's Go Eevee",
                "Brilliant Diamond/Shining Pearl",
                "Legends: Arceus",
                "Scarlet/Violet",
                "The Isle of Armor"
            }; 
            return allGames[UserInputHandler.UserSelectFrom(allGames)];

        }
        
    }
}
