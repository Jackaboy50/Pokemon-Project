using Pokemon_Battle_Sim__Console_.Functionality_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Menu_Classes
{
    internal static class BattleMenu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Battle Simulator menu");
            Console.WriteLine("What would you like to do?");
            List<string> menuOptions = new List<string>()
            {
                "Play against AI",
                "Play against a friend locally",
                "Watch an AI battle",
                "Return to Main Menu"
            };
            int userChoice = UserInputHandler.UserSelectFrom(menuOptions);

            switch (userChoice)
            {
                case 0:
                    PlayAgainstAIMenu();
                    break;

                case 1:
                    PlayAgainstFriend();
                    break;

                case 2:
                    WatchAIBattle();
                    break;

                case 3:
                    return;
            }
        }

        static void PlayAgainstAIMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an AI Tier (1 - 5)");
            int aiChoice = UserInputHandler.GetUserIntegerInRange(1, 5);

        }

        static void PlayAgainstFriend()
        {
            
        }

        static void WatchAIBattle()
        {
            Console.Clear();
            Console.WriteLine("Select an AI Tier for Player 1 (1 - 5)");
            int P1aiChoice = UserInputHandler.GetUserIntegerInRange(1, 5);
            Console.WriteLine("Select an AI Tier for Player 2 (1 - 5)");
            int P2aiChoice = UserInputHandler.GetUserIntegerInRange(1, 5);
        }
    }
}
