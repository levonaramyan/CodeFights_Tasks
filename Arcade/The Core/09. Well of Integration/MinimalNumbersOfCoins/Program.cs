using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You find yourself in Bananaland trying to buy a banana. You are super rich so you have
// an unlimited supply of banana-coins, but you are trying to use as few coins as possible.
// The coin values available in Bananaland are stored in a sorted array coins.coins[0] = 1,
// and for each i (0 < i<coins.length) coins[i] is divisible by coins[i - 1].
// Find the minimal number of banana-coins you'll have to spend to buy a banana given the banana's price.
// Example:
//          For coins = [1, 2, 10] and price = 28, the output should be
//          minimalNumberOfCoins(coins, price) = 6.
//          You have to use 10 twice, and 2 four times.

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
