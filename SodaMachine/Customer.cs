using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Customer
    {
        //member variables
        public Wallet wallet;
        public Backpack backpack;
        public List<Coin> payment;
        Quarter quarter;
        Dime dime;
        Nickel nickel;
        Penny penny;

        //constructor
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            payment = new List<Coin>();

        }

        //member methods
        //Get user input for type of coin they'd like to add (Let's use integers again)
        //Will then check if wallet has that coin
                //if it does we will add the coin and display what our total cost is
                //then have option to add more funds or add to machine (Integer user input


        public void AddToPayment(Coin coin)
        {
            Interface.GetUserInputInt("");
            if (wallet.coins.Contains(coin))
            {
                wallet.coins.Remove(coin);
                payment.Add(coin);
                Console.WriteLine($"Your current total cost is: {Math.ComputeTotalPayment(payment)}");
            }
            else
            {
                Interface.InsufficientMoney();
            }
        }

        public Coin SelectCoin()
        {
            Interface.DisplayCoinOptions();
            int userSelection = Interface.GetUserInputInt("Please enter the number of the coin you'd like to add to your payment:");

            switch (userSelection)
            {
                case 1:
                    return quarter;

                case 2:
                    return dime;

                case 3:
                    return nickel;

                case 4:
                    return penny;

                default:
                    Interface.InvalidSelection();
                    return SelectCoin();
            }

        }
       
    }
}
