using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Machine
    {
        //member variables
        public List<Coin> register;
        public List<Can> inventory;
        public List<Coin> receivedPayment;

        Quarter quarter;
        Dime dime;
        Nickel nickel;
        Penny penny;

        OrangeSoda orangeSoda;
        RootBeer rootBeer;
        Cola cola;

        //constructor
        public Machine()
        {
            inventory = new List<Can>();
            InitializeInventory();
            register = new List<Coin>();
            InitializeRegister();

            receivedPayment = new List<Coin>();
        }
        public void InitializeInventory()
        {
            for (int i = 0; i < 10; i++)
            {
                orangeSoda = new OrangeSoda();
                inventory.Add(orangeSoda);
            }
            for (int i = 0; i < 10; i++)
            {
                rootBeer = new RootBeer();
                inventory.Add(rootBeer);
            }
            for (int i = 0; i < 10; i++)
            {
                cola = new Cola();
                inventory.Add(cola);
            }
        }
        
        public void InitializeRegister()
        {
            for (int i = 0; i < 20; i++)
            {
                quarter = new Quarter();
                register.Add(quarter);
            }
            //20 quarters
            for (int i = 0; i < 10; i++)
            {
                dime = new Dime();
                register.Add(dime);
            }
            //10 dimes
            for (int i = 0; i < 20; i++)
            {
                nickel = new Nickel();
                register.Add(nickel);
            }
            for (int i = 0; i < 50; i++)
            {
                penny = new Penny();
                register.Add(penny);
            }
        }

        //member methods   
        public void DisplayInventory()
        {
            int colaCount = 0;
            int rootBeerCount = 0;
            int orangeSodaCount = 0;
            foreach (Can can in inventory)
            {
                if (can.Name == "Cola")
                {
                    colaCount++;
                }
                else if (can.Name == "Root Beer")
                {
                   rootBeerCount++;
                }
                else if (can.Name == "Orange Soda")
                {
                    orangeSodaCount++;
                }
            }
            Interface.DisplaySodaInventory(colaCount, rootBeerCount, orangeSodaCount);
        }
        public double ComputeRegisterValue()
        {
            double totalRegisterValue = 0;
            foreach(Coin coin in register)
            {
                totalRegisterValue += coin.Value;
            }
            return totalRegisterValue;
        }
       
        public void AddPayment(List<Coin> receivedPayment)
        {
            foreach (Coin coin in receivedPayment)
            {
                register.Add(coin);
            }
            receivedPayment.Clear();
        }

        public List<Coin> ComputeChangeList(Double changeToDispense)
        {
            List<Coin> changeList = new List<Coin>();

            while (changeToDispense > 0)
            {
                //Check if divisible by 5 -> if % 5 != 0 --> take that number, see if it's greater than 
                if ((changeToDispense / 0.25 > 1) && (register.Contains(quarter)))
                {
                    register.Remove(quarter);
                    changeList.Add(quarter);
                    changeToDispense -= 0.25;
                }
                else if ((changeToDispense / 0.10 > 1) && (register.Contains(dime)))
                {
                    register.Remove(dime);
                    changeList.Add(dime);
                    changeToDispense -= 0.10;
                }
                else if ((changeToDispense / 0.05 > 1) && (register.Contains(nickel)))
                {
                    register.Remove(nickel);
                    changeList.Add(nickel);
                    changeToDispense -= 0.05;
                }
                else if ((changeToDispense / 0.01 > 1) && (register.Contains(penny)))
                {
                    register.Remove(penny);
                    changeList.Add(penny);
                    changeToDispense -= 0.01;
                }
            }
            return changeList;
        }
        public void AssessPayment(Customer customer, Can canSelection)
        {
            double totalPayment = Math.Round(Computations.ComputeTotalPayment(customer.payment), 2);
            double paymentChange = totalPayment - canSelection.Cost;
           

            if (totalPayment < canSelection.Cost)
            {
                Interface.DisplayMessage("Insufficient money provided.  Soda will not be dispensed and funds will be returned.");
                customer.AddToWallet(customer.payment);
            }
            else if (!MachineHasCan(canSelection))
            {
                Interface.DisplayMessage("Insufficient soda in inventory.  Soda will not be dispensed and funds will be returned.");
                customer.AddToWallet(customer.payment);
            }
            else if (paymentChange > ComputeRegisterValue())
            {
                Interface.DisplayMessage("Insufficient change in machine.  Soda will not be dispensed and funds will be returned.");
                customer.AddToWallet(customer.payment);
            }
            else if (totalPayment >= canSelection.Cost && (MachineHasCan(canSelection)))
            {
                if (NeedsChange(totalPayment, canSelection))
                {
                    double changeToDispense = totalPayment - canSelection.Cost;
                    DispenseSoda(canSelection);
                    Interface.DisplayMessage($"Your change is {changeToDispense}");
                    customer.AddToWallet(ComputeChangeList(changeToDispense));
                }
                else
                {
                    DispenseSoda(canSelection);
                    customer.backpack.AddCan(canSelection);
                }
            }
        }
        public bool MachineHasCan(Can canSelection)
        {
           foreach (Can can in inventory)
            {
                if (can.Name == canSelection.Name)
                {
                    return true;
                }
            }
            return false;
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
        public void DispenseSoda(Can canSelection)
        {
            inventory.Remove(canSelection);
            Interface.DisplayMessage($"Successfully purchased {canSelection.Name}!");
        }
    }
}
