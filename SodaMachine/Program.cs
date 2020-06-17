using System;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();

            
            //We can display the inventory of the machine and the cost of each soda
                //Could add in a feature to display this based on user input later
            //User will select soda to purchase, machine will display price remaining
                        //Can use property logic for payment method
                            //if (moneyInput = can.cost) ------> give soda, add soda to backpack, display success message
                            //if (moneyInput < can.cost) -------> display unsuccessful message, return change
                            //if (moneyInput > can.cost && (moneyInput - can.cost > machine.register) ------> display unsuccessful message, return change
                            //if (moneyInput > can.cost) -------->DISPENSECHANGE METHOD
                                //Could use / for this with series of cases for what we want to return for change
                                        //IF remainder > .25 ---> Dispense quarter etc etc.
        }
    }
}
