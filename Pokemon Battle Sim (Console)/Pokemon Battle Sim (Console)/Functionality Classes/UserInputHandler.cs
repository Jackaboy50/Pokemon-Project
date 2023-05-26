using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_.Functionality_Classes
{
    internal static class UserInputHandler
    {
        /// <summary>
        /// Gets a valid integer input from the user
        /// </summary>
        /// <returns>Returns the integer input</returns>
        public static int GetUserInteger()
        {
            int input = 0;
            bool complete = false;
            while (!complete)
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Error, user input not in number format");
                }
                else
                {
                    complete = true;
                }
            }
            return input;
        }

        /// <summary>
        /// Gets a valid float input from the user
        /// </summary>
        /// <returns>Returns the float input</returns>
        public static float GetUserFloat()
        {
            float input = 0.0f;
            bool complete = false;
            while (!complete)
            {
                if (!float.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Error, user input not in number format");
                }
                else
                {
                    complete = true;
                }
            }
            return input;
        }

        /// <summary>
        /// Uses a given range to have the user pick an integer within said range
        /// </summary>
        /// <param name="min">The minimum integer the user can input</param>
        /// <param name="max">The maximum integer the user can input</param>
        /// <returns></returns>
        public static int GetUserIntegerInRange(int min, int max)
        {
            int input = GetUserInteger();
            while (input < min || input > max)
            {
                Console.WriteLine($"Error, input not in range: {min} - {max} inclusive");
                input = GetUserInteger();
            }
            return input;
        }

        /// <summary>
        /// Used to get a valid string input from the user
        /// </summary>
        /// <returns>Returns the string input=</returns>
        public static string GetUserString()
        {
            string input = Console.ReadLine();
            while (input == string.Empty)
            {
                Console.WriteLine("Error, enter a non-empty string");
                input = Console.ReadLine();
            }
            return input;
        }

        public static int UserSelectFrom(List<string> choices)
        {
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }
            Console.WriteLine();
            return GetUserIntegerInRange(1, choices.Count) - 1;
        }

        public static string UserYesOrNo()
        {
            string input = Console.ReadLine().ToUpper();
            while(input != "N" && input != "Y")
            {
                Console.WriteLine("Please enter Y/N");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
