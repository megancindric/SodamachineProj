using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    abstract class Can
    {
        //member variables
        protected string name;
        protected double cost;
        public double Cost
        {
            get
            {
                return cost;
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
        public Can()
        {

        }

        //member methods
    }
}
