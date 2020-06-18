using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Backpack
    {
        //member variables
            //Will have a list of cans in backpack
        public List<Can> cans;
        //constructor
        public Backpack()
        {
            cans = new List<Can>();
        }

        //member methods
        public void AddCan(Can soda)
        {
            cans.Add(soda);
        }

        public void DisplayBackpack()
        {
            Interface.DisplayMessage("Currently you have the following sodas in your backpack:");
            foreach(Can can in cans)
            {
                Interface.DisplayMessage(can.Name);
            }
        }
    }
}
