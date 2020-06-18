using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Wallet
    {
        //member variables
        public List<Coin> coins;
        public Card card;
        Nickel nickel;
        Penny penny;
        Dime dime;
        Quarter quarter;
        //constructor
        public Wallet()
        {
            card = new Card();
            coins = new List<Coin>();
            AddCoins();
        }
        public void AddCoins()
        {
            for (int i = 0; i < 12; i++)
            {
                quarter = new Quarter();
                coins.Add(quarter);
            }
            for (int i = 0; i < 13; i++)
            {
                dime = new Dime();
                coins.Add(dime);
            }
            for (int i = 0; i < 12; i++)
            {
                nickel = new Nickel();
                coins.Add(nickel);
            }
            for (int i = 0; i < 10; i++)
            {
                penny = new Penny();
                coins.Add(penny);
            }
        }
        //member methods
        public void DisplayWallet()
        {
            int quarterCount = 0;
            int dimeCount = 0;
            int nickelCount = 0;
            int pennyCount = 0;

            foreach (Coin coin in coins)
            {
                if (coin.Name == "Quarter")
                {
                    quarterCount++;
                }
                else if (coin.Name == "Dime")
                {
                    dimeCount++;
                }
                else if (coin.Name == "Nickel")
                {
                    nickelCount++;
                }
                else if (coin.Name == "Penny")
                {
                    pennyCount++;
                }
            }
            Interface.DisplayCoinsInWallet(quarterCount, dimeCount, nickelCount, pennyCount);
        }
       
    }
}
