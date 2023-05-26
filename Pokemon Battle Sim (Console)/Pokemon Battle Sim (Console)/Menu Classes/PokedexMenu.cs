using Aspose.Imaging.FileFormats.Emf.EmfPlus.Records;
using Pokemon_Battle_Sim__Console_.Functionality_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Menu_Classes
{
    internal static class PokedexMenu
    {
        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Pokedex Menu");
                Console.WriteLine("What would you like to do?");
                List<string> menuOptions = new List<string>()
                {
                    "Display All Pokemon",
                    "Display All Moves",
                    "Display All Abilities",
                    "Return to Main Menu"
                };
                int userChoice = UserInputHandler.UserSelectFrom(menuOptions);

                switch (userChoice)
                {
                    case 0:
                        DisplayAllPokemon();
                        Console.WriteLine();
                        Console.WriteLine("Would you like to select a view filter? Y or N to return to menu");
                        string choice = UserInputHandler.UserYesOrNo();
                        if (choice == "Y")
                        {
                            SelectPokedexFilter();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to menu");
                            Console.ReadKey();
                        }
                        break;

                    case 1:

                        break;

                    case 2:
                        return;
                }
            }
        }

        static void DisplayAllPokemon()
        {
            Console.Clear();
            Console.WriteLine("Here is a list of all Pokemon");
            Console.WriteLine("------------------------------------------------");
            foreach (Pokemon p in Functions.allPokemon)
            {
                Console.WriteLine($"#{p.nationalDexNum} {p.Name}");
            }
            Console.WriteLine("------------------------------------------------");
        }

        static void DisplayAllPokemonByType(string typeFilter)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Here is a list of all {typeFilter} type Pokemon");
            Console.WriteLine("------------------------------------------------");
            foreach (Pokemon p in Functions.allPokemon)
            {
                if(p.Type1.Name.ToLower() == typeFilter || (p.Type2 != null && p.Type2.Name == typeFilter))
                {
                    Console.WriteLine($"#{p.nationalDexNum} {p.Name}");
                }
            }
            Console.WriteLine("------------------------------------------------");
        }

        static void DisplayAllPokemonByGame(string gameFilter)
        {
            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Here is a list of all Pokemon from {gameFilter}");
            Console.WriteLine("------------------------------------------------");
            foreach(Pokemon p in Functions.allPokemon)
            {
                if (p.featuredGames.Contains(gameFilter))
                {
                    int index = p.featuredGames.IndexOf(gameFilter);
                    Console.WriteLine($"#{p.localDexNumbers[index]} {p.Name}");
                }
            }
            Console.WriteLine("------------------------------------------------");
        }

        static void DisplayAllPokemonByGeneration(int generationFilter)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Here is a list of all Pokemon from Generation {generationFilter}");
            Console.WriteLine("------------------------------------------------");
            foreach (Pokemon p in Functions.allPokemon)
            {
                if(p.generation == generationFilter)
                {
                    Console.WriteLine($"#{p.nationalDexNum} {p.Name}");
                }
            }
            Console.WriteLine("------------------------------------------------");
        }

        static void DisplayAllPokemonByMove(string moveFilter)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Here is a list of all Pokemon that can learn the move {moveFilter}");
            Console.WriteLine("------------------------------------------------");
            foreach (Pokemon p in Functions.allPokemon)
            {
                if (p.possibleMoves.Contains(Functions.UpperStartingLetters(moveFilter)))
                {
                    Console.WriteLine($"#{p.nationalDexNum} {p.Name}");
                }
            }
            Console.WriteLine("------------------------------------------------");
        }

        static void SelectPokedexFilter()
        {
            Console.Clear();
            Console.WriteLine("What type of filter do you want?");
            List<string> filterTypes = new List<string>()
            {
                "Filter by Type",
                "Filter by Generation",
                "Filter by Move",
                "Filter by Game",
                "Exit filter selection"
            };
            int userChoice = UserInputHandler.UserSelectFrom(filterTypes);

            switch (userChoice)
            {
                case 0:
                    DisplayAllPokemonByType(PokedexFilterMenu.SelectTypeFilter());
                    break;

                case 1:
                    DisplayAllPokemonByGeneration(PokedexFilterMenu.SelectGenerationFilter());
                    break;

                case 2:
                    DisplayAllPokemonByMove(PokedexFilterMenu.SelectMoveFilter());

                    break;

                case 3:
                    DisplayAllPokemonByGame(PokedexFilterMenu.SelectGameFilter());
                    break;

                case 4:
                    return;
            }
        }
        
    }
}
