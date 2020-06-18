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
            Interface.DisplayMessage("Welcome to the soda machine!");
            sodaMachine.DisplayInventory();
            Can canSelection = sodaMachine.SelectSoda();
            //Method for customer to add money to payment
            AssessPayment(sodaMachine, customer, canSelection);
        }

        //member methods
        

        public void AssessPayment(Machine sodaMachine, Customer customer, Can canSelection)
        {
            double totalPayment = Math.ComputeTotalPayment(customer.payment);
            double paymentChange = totalPayment - canSelection.Cost;

            if (!SufficientPayment(totalPayment, canSelection))
            {
                UnderPayment();
            }
            else if (!MachineHasCan(canSelection))
            {
                InsufficientInventory();
            }
            else if (paymentChange > sodaMachine.ComputeRegisterValue())
            {
                InsufficientMoneyInMachine();
            }
            else if (SufficientPayment(totalPayment, canSelection) && (MachineHasCan(canSelection)))
            {
                if (NeedsChange(totalPayment, canSelection))
                {
                    double changeToDispense = totalPayment - canSelection.Cost;
                    DispenseSoda();
                    customer.AddToWallet(sodaMachine.ComputeChangeList(changeToDispense));
                }
                else
                {
                    DispenseSoda();
                }
            }
        }
        public bool MachineHasCan(Can canSelection)
        {
            if (sodaMachine.inventory.Contains(canSelection))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool NeedsChange(Double totalPayment, Can canSelection)
        {
            if (totalPayment == canSelection.Cost)
            {
                return false;
            }
            else
            { 
                return true;
            }
        }
        public bool SufficientPayment(Double totalPayment, Can canSelection)
        {
            if (totalPayment > canSelection.Cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DispenseSoda()
        {
            Can canSelection = sodaMachine.SelectSoda();
            sodaMachine.inventory.Remove(canSelection);
            customer.backpack.AddCan(canSelection);
            Interface.DisplayMessage($"Successfully purchased {canSelection.Name}!");
        }
        public void InsufficientInventory()
        {
            Interface.DisplayMessage("Insufficient soda in inventory.  Soda will not be dispensed and funds will be returned.");
            customer.AddToWallet(sodaMachine.receivedPayment);
        }
        public void InsufficientMoneyInMachine()
        {
            Interface.DisplayMessage("Insufficient change in machine.  Soda will not be dispensed and funds will be returned.");
            customer.AddToWallet(sodaMachine.receivedPayment);
        }
        public void UnderPayment()
        {
            Interface.DisplayMessage("Insufficient money provided.  Soda will not be dispensed and funds will be returned.");
            customer.AddToWallet(sodaMachine.receivedPayment);
        }
        public void SelectFromMenu()
        {
            Interface.DisplayMenuOptions();
            int userInput = Interface.GetUserInputInt("Please enter your number selection");

            switch (userInput)
            {
                case 1:
                    {
                        sodaMachine.SelectSoda();
                        break;
                    }
                case 2:
                    {
                        sodaMachine.DisplayInventory();
                        SelectFromMenu();
                        break;
                    }
                case 3:
                    {
                        customer.wallet.DisplayWallet();
                        SelectFromMenu();
                        break;
                    }

                case 4:
                    {
                        Interface.DisplayMessage("Thanks for playing!");
                        break;
                    }

                default :
                    {
                        Interface.InvalidSelection();
                        SelectFromMenu();
                        break;
                    }
            }
        }
    }
}
