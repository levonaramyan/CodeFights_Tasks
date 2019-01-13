using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalNumbersOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int minimalNumberOfCoins(int[] coins, int price)
        {
            int coinNum = 0;
            int index = 0;
            while (index < coins.Length && price > coins[index])
            {
                index++;
            }

            index--;

            while (price > 0)
            {
                coinNum += price / coins[index];
                price = price % coins[index];
                index--;
            }

            return coinNum;

        }

    }
}
