using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SodaMachine
{
    class Simulation
    {
        //member variables
        //Will have a SodaMachine and a Customer object
        public Machine sodaMachine;
        public Customer customer;

        //constructor
        public Simulation()
        {
            sodaMachine = new Machine();
            customer = new Customer();
        }

        //member methods
        public void InsertPayment(List<Coin> customerPayment)
        {
                sodaMachine.receivedPayment = customerPayment;
        }
       
        public void ReturnPayment(List<Coin> receivedPayment)
        {
            customer.wallet.coins = receivedPayment;
        }
        
        public void InsufficientFunds()
        {
            Interface.InsufficientMoney();
            ReturnPayment(sodaMachine.receivedPayment);
        }

        public void InsufficientInventory()
        {
            Interface.InsufficientInventory();
            ReturnPayment(sodaMachine.receivedPayment);
        }
        public void UnderPayment()
        {
            Interface.InsufficientMoney();
            ReturnPayment(sodaMachine.receivedPayment);
        }
        public double ComputeTotalPayment(List<Coin> coinList)
        {
            double totalPayment = 0;
            foreach (Coin coin in coinList)
            {
                totalPayment += coin.Value;
            }
            return totalPayment;
        }

        public void AssessPayment(double totalPayment, Can colaSelection)
        {
            if (totalPayment < colaSelection.Cost)
            {
                UnderPayment();
            }
           
        }

        public void OverPayment()
        {

        }

       
    }
}
