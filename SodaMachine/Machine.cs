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
        public void AddPayment(List<Coin> receivedPayment)
        {
            foreach (Coin coin in receivedPayment)
            {
                register.Add(coin);
            }
        }
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
            Console.WriteLine("The current inventory is:");
            Console.WriteLine($"1: {colaCount} cans of Cola (${cola.Cost} per can)");
            Console.WriteLine($"2. {rootBeerCount} cans of Root Beer (${rootBeer.Cost} per can)");
            Console.WriteLine($"3. {orangeSodaCount} cans of Orange Soda (${orangeSoda.Cost} per can)");
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

       
        public void InsertPayment(List<Coin> customerPayment)
        {
            receivedPayment = customerPayment;
        }
        public void DispenseSoda()
        {
            //how can we translate a specific user input to a type of soda can?
        }
        public void SelectSoda()
        {
            switch (Interface.GetUserInputInt("Please enter the number of your soda choice!"))
            {
                case 1:
                    Console.WriteLine("Cola selected.");
                    break;

                case 2:
                    Console.WriteLine("Root Beer selected.");
                    break;

                case 3:
                    Console.WriteLine("Orange Soda selected");
                    break;

                default:
                    Console.WriteLine("Not a valid soda selection. Please try again!");
                    SelectSoda();
                    break;
            }
        }
    }
}
