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
            Console.WriteLine("Insufficent funds.  Please try again.");
        }

        public static void InsufficientInventory()
        {
            Console.WriteLine("Insufficient soda in inventory.  Soda will not be dispensed and funds will be returned to you.");
        }
        public static void DisplayCoinOptions()
        {
            Console.WriteLine("Press 1 for Quarter");
            Console.WriteLine("Press 2 for Dime");
            Console.WriteLine("Press 3 for Nickel");
            Console.WriteLine("Press 4 for Penny");
        }
        
        public static void DisplayPurchaseOptions()
        {
            Console.WriteLine("Press 1 to continue adding coins");
            Console.WriteLine("Press 2 to insert all coins into machine");
        }

        public static void InvalidSelection()
        {
            Console.WriteLine("Invalid selection detected.  Please try again.");
        }

    }
}
