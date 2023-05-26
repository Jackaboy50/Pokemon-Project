using Pokemon_Battle_Sim__Console_.Menu_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Functionality_Classes
{
    internal static class MenuHandler
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Pokemon Battle Simulator and Pokedex");
            Console.WriteLine("What would you like to do?");
            List<string> menuOptions = new List<string>()
            {
                "Use the Battle Simulator",
                "Open the Team Builder",
                "View the Pokedex",
                "Exit the menu",
            };
            int userChoice = UserInputHandler.UserSelectFrom(menuOptions);
            switch (userChoice)
            {
                case 0:

                    break;

                case 1:
                    BattleMenu.MainMenu();
                    break;

                case 2:
                    PokedexMenu.MainMenu();
                    break;

                case 3:
                    return;
            }
        }
    }
}
