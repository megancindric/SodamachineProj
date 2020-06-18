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

        //edit this method
        public void AddToWallet(List<Coin> changeList)
        {
            foreach (Coin coin in changeList)
            {
                wallet.coins.Add(coin);
            }
            changeList.Clear();
        }
        
        public void AddToPayment(Coin coinToAdd)
        {
            if (!WalletHasCoin(coinToAdd))
            {
                Interface.DisplayMessage("Insufficient coins in wallet for this selection.  Please try again.");
            }
            else
            {
                wallet.coins.Remove(coinToAdd);
                payment.Add(coinToAdd);
                Interface.DisplayMessage($"Your current total payment is: {Math.ComputeTotalPayment(payment)}");
            }
        }
        public bool WalletHasCoin(Coin coinToAdd)
        {
            foreach (Coin coin in wallet.coins)
            {
                if (coin.Name == coinToAdd.Name)
                {
                    return true;
                }
            }
            return false;
        }
        public void SelectPaymentOption()
        {
            Interface.DisplayPurchaseOptions();
            int userSelection = Interface.GetUserInputInt("Please enter your selection:");
            switch (userSelection)
            {
                case 1:
                    {
                        AddToPayment(SelectCoin());
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
                Interface.DisplayCoinOptions();
                int userSelection = Interface.GetUserInputInt("Please select the coin you'd like to add to your payment:");

                 switch (userSelection)
                 {
                     case 1:
                            return new Quarter();
                     case 2:
                            return new Dime();
                     case 3:
                            return new Nickel();
                     case 4:
                            return new Penny();
                     default:
                            Interface.InvalidSelection();
                            return SelectCoin();
                 }
            }
    }
}
