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

        //constructor
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            payment = new List<Coin>();
        }

        //member methods
        public void AddToWallet(List<Coin> changeList)
        {
            foreach (Coin coin in changeList)
            {
                changeList.Remove(coin);
                wallet.coins.Add(coin);
            }
        }
        public void CreatePayment()
        {
            SelectPaymentOption();

            
        }
        public void AddToPayment()
        {
            Coin coinToAdd = SelectCoin();
            if (wallet.coins.Contains(coinToAdd))
            {
                wallet.coins.Remove(coinToAdd);
                payment.Add(coinToAdd);
                Interface.DisplayMessage($"Your current total payment is: {Math.ComputeTotalPayment(payment)}");
            }
            else
            {
                Interface.DisplayMessage("Insufficient coins in wallet for this selection.  Please try again.");
            }
        }
        public void SelectPaymentOption()
        {
            Interface.DisplayPurchaseOptions();
            //1 to add a coin, 2 to submit payment, 3 to display wallet
            //2 is the only case where we break and move on to submitting payment
            int userSelection = Interface.GetUserInputInt("Please enter your selection:");
            switch (userSelection)
            {
                case 1:
                    {
                        SelectCoin();
                        SelectPaymentOption();
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        wallet.DisplayWallet();
                        SelectPaymentOption();
                        break;
                    }
                default:
                    {
                        Interface.InvalidSelection();
                        SelectPaymentOption();
                        break;
                    }
            }
        }
            public Coin SelectCoin()
        {
            Coin coinSelection;
            Interface.DisplayCoinOptions();
            int userSelection = Interface.GetUserInputInt("Please select the coin you'd like to add to your payment:");

            switch (userSelection)
            {
                case 1:
                    {
                        coinSelection = new Quarter();
                        return coinSelection;
                    }
                    

                case 2:
                    {
                        coinSelection = new Dime();
                        return coinSelection;
                    }
                   

                case 3:
                    {
                        coinSelection = new Nickel();
                        return coinSelection;
                    }
                    

                case 4:
                    {
                        coinSelection = new Penny();
                        return coinSelection;
                    }
                   

                default:
                    {
                        Interface.InvalidSelection();
                        return SelectCoin();
                    }      
            }
        }
    }
}
