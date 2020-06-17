using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SodaMachine
{
    class Simulation
    {
        //member variables
        public Machine sodaMachine;
        public Customer customer;

        //constructor
        public Simulation()
        {
            sodaMachine = new Machine();
            customer = new Customer();
            Interface.DisplayWelcome();
            sodaMachine.DisplayInventory();
            sodaMachine.SelectSoda();
        }

        //member methods
        public void ReturnPayment(List<Coin> receivedPayment)
        {

        }

        public void InsufficientInventory()
        {
            Interface.InsufficientInventory();
            ReturnPayment(sodaMachine.receivedPayment);
        }
        public void InsufficientMoneyInMachine()
        {
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

        public void AssessPayment(Machine sodaMachine, Customer customer, Can canSelection)
        {
            double totalPayment = ComputeTotalPayment(customer.payment);

            if (totalPayment < canSelection.Cost)
            {
                UnderPayment();
            }
            else if (!sodaMachine.inventory.Contains(canSelection))
            {
                InsufficientInventory();
            }
            else if (totalPayment - canSelection.Cost > sodaMachine.ComputeRegisterValue())
            {
                InsufficientMoneyInMachine();
            }
            else if (totalPayment == canSelection.Cost)
            {
                ExactPayment();
            }
            else if (totalPayment > canSelection.Cost)
            {
                OverPayment();
            }
        }

        public void OverPayment()
        {

        }
        
        public void ExactPayment()
        {

        }

       
    }
}
