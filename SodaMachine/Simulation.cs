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

            SelectFromMenu();

            sodaMachine.InsertPayment(customer.payment);
            //will need to  do assesspayment method
            //then will need to do correct response;
        }
        //member methods
        public void PurchaseASoda()
        {
            Can customerSelection = SelectSoda();
            //Will use this can for cost & soda machine methods
            customer.SelectPaymentOption();
            //Now have customer payment
            sodaMachine.AssessPayment(customer, customerSelection);
            //Will use cost of this can w/ payment methods

            //If successful purchase...
            customer.backpack.AddCan(customerSelection);
        }
        public void SelectFromMenu()
        {
            Interface.DisplayMenuOptions();
            int userInput = Interface.GetUserInputInt("Please enter your number selection");
            switch (userInput)
            {
                case 1:
                        PurchaseASoda();
                        break;
                case 2:
                        sodaMachine.DisplayInventory();
                        SelectFromMenu();
                        break;
                case 3:
                        customer.wallet.DisplayWallet();
                        SelectFromMenu();
                        break;
                case 4:
                        customer.backpack.DisplayBackpack();
                        SelectFromMenu();
                        break;
                case 5:
                        Interface.DisplayMessage("Thanks for playing!");
                        break;
                default :
                        Interface.InvalidSelection();
                        SelectFromMenu();
                        break;
            }
        }
        public Can SelectSoda()
        {           
            Interface.DisplaySodaOptions();
            switch (Interface.GetUserInputInt("Please enter the number of your soda choice!"))
            {
                case 1:
                    Interface.DisplayMessage("Cola selected.  Please insert money");
                    return new Cola();
                case 2:
                    Interface.DisplayMessage("Root Beer selected.  Please insert money");
                    return new RootBeer();
                case 3:
                    Interface.DisplayMessage("Orange Soda selected  Please insert money");
                    return new OrangeSoda();
                default:
                    Interface.InvalidSelection();
                    return SelectSoda();
            }
        }
    }
}
