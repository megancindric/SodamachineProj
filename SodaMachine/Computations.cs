using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    static class Computations
    {
        public static double ComputeTotalPayment(List<Coin> coinList)
        {
            double totalPayment = 0;
            foreach (Coin coin in coinList)
            {
                totalPayment += coin.Value;
            }
            Math.Round(totalPayment, 2);
            return totalPayment;
        }
    }
}
