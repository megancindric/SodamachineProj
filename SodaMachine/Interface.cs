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

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayMenuOptions()
        {
            Console.WriteLine("Your menu options are:");
            Console.WriteLine("1. Buy a soda");
            Console.WriteLine("2. Display soda in inventory");
            Console.WriteLine("3. Display your available money");
            Console.WriteLine("4. Display sodas in your backpack");
            Console.WriteLine("5. Exit");
        }
       
        public static void DisplaySodaOptions()
        {
            Console.WriteLine($"Press 1 for Cola ($0.35 per can)");
            Console.WriteLine($"Press 2 for Root Beer ($0.60 per can)");
            Console.WriteLine($"Press 3 for Orange Soda ($0.06 per can)");
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
            Console.WriteLine("Press 1 to add a coin from your wallet");
            Console.WriteLine("Press 2 to insert your payment into the machine");
            Console.WriteLine("Press 3 to display money in your wallet");
            //third case display wallet
        }
        public static void DisplayCoinsInWallet(int quarterCount, int dimeCount, int nickelCount, int pennyCount)
        {
            Console.WriteLine("The current money in your wallet is:");
            Console.WriteLine($"Quarters: {quarterCount}");
            Console.WriteLine($"Dimes: {dimeCount}");
            Console.WriteLine($"Nickels: {nickelCount}");
            Console.WriteLine($"Pennies: {pennyCount}");
        }
        public static void DisplaySodaInventory(int colaCount, int rootBeerCount, int orangeSodaCount)
        {
            Console.WriteLine("The current inventory is:");
            Console.WriteLine($"1: {colaCount} cans of Cola.");
            Console.WriteLine($"2. {rootBeerCount} cans of Root Beer");
            Console.WriteLine($"3. {orangeSodaCount} cans of Orange Soda");
        }
        public static void InvalidSelection()
        {
            Console.WriteLine("Invalid selection detected.  Please try again.");
        }

    }
}
