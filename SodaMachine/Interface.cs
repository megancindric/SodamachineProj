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

        public static void SelectSoda()
        {
            Console.WriteLine("Please select your soda");
            String sodaSelection = Console.ReadLine();
            switch (sodaSelection)
            {
                case "Cola":
                    Console.WriteLine("Cola selected.");
                    break;

                case "Root Beer":
                        Console.WriteLine("Root Beer selected.");
                        break;

                case "Orange Soda":
                        Console.WriteLine("Orange Soda selected");
                        break;

                default:
                        Console.WriteLine("Not a valid soda selection. Please try again!");
                        SelectSoda();
                        break;

            }
        }

        public static void SelectCoinPayment()
        {

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
