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
        //Will have a list of coins and a Card
        //constructor
        public Wallet()
        {
            card = new Card();
            coins = new List<Coin>();
            //Do we want to assign pre-determined coin amount?
            //Will be $5 in mixed change - let's do:
                //12 Quarters (3.00)
                //13 Dimes ($1.30)
                //12 Nickels (0.60)
                //10 Pennies (0.10)
        }

        //member methods
        public void DisplayWallet()
        {
            //Will log value of card (can do method for this) as well as number of each type of coin
            Console.WriteLine("The current money in your wallet is:");

        }
       
    }
}
