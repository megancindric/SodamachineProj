using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    abstract class Coin
    {
        //member variables
        protected double value;
        protected string name;
        //Will have a PROTECTED value and a PUBLIC value (both doubles)
        public double Value
        {
            get
            {
                return value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        //constructor
        public Coin()
        {

        }

        //member methods
    }
}
