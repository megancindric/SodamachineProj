﻿using System;
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
            Interface.DisplayMessage("The current inventory is:");
            Interface.DisplayMessage($"1: {colaCount} cans of Cola (${cola.Cost} per can)");
            Interface.DisplayMessage($"2. {rootBeerCount} cans of Root Beer (${rootBeer.Cost} per can)");
            Interface.DisplayMessage($"3. {orangeSodaCount} cans of Orange Soda (${orangeSoda.Cost} per can)");
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
        public void AddPayment(List<Coin> receivedPayment)
        {
            foreach (Coin coin in receivedPayment)
            {
                register.Add(coin);
            }
        }
        public Can SelectSoda()
        {
            switch (Interface.GetUserInputInt("Please enter the number of your soda choice!"))
            {
                case 1:
                    Interface.DisplayMessage("Cola selected.  Please insert money");
                    return cola;
                    
                case 2:
                    Interface.DisplayMessage("Root Beer selected.  Please insert money");
                    return rootBeer;

                case 3:
                    Interface.DisplayMessage("Orange Soda selected  Please insert money");
                    return orangeSoda;

                default:
                    Interface.InvalidSelection();
                    return SelectSoda();
            }
        }

        public List<Coin> ComputeChangeList(Double changeToDispense)
        {
            List<Coin> changeList = new List<Coin>();

            while (changeToDispense > 0)
            {
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
    }
}
