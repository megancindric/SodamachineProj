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
            //Will have a Wallet (with money) and Backpack(with a list of Cans)

        //constructor
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            payment = new List<Coin>();

        }

        //member methods
        public void AddToPayment(Coin coin)
        {
            if (wallet.coins.Contains(coin))
            {
                wallet.coins.Remove(coin);
                payment.Add(coin);
            }
            else
            {
                Console.WriteLine($"Whoops!  Looks like you're out of {coin.Name}.  Try again!");
                //Will be moved to interface class
            }
        }


       
    }
}
