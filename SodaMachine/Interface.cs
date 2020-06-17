using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public static class Interface
    {
        public static void DisplayPrice()
        {
            Console.WriteLine($"The price of your soda is");
        }

       public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static int GetUserInputInt(string prompt)
        {
            Console.WriteLine(prompt);
            int userInput = Int32.Parse(Console.ReadLine());
            return userInput;
        }

        public static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the soda machine!");
        }

        public static void InsufficientMoney()
        {
            Console.WriteLine("Insufficent money provided.  Soda will not be dispensed and funds will be returned to you.");
        }

        public static void InsufficientInventory()
        {
            Console.WriteLine("Insufficient soda in inventory.  Soda will not be dispensed and funds will be returned to you.");
        }
        
    }
}
