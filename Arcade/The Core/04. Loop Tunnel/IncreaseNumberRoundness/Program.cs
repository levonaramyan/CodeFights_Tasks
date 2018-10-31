using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define an integer's roundness as the number of trailing zeroes in it.
// Given an integer n, check if it's possible to increase n's roundness by swapping some pair of its digits.

// Example
//          For n = 902200100, the output should be
//          increaseNumberRoundness(n) = true.
//          One of the possible ways to increase roundness of n is to swap digit 1 with digit 0 preceding it:
//          roundness of 902201000 is 3, and roundness of n is 2.
//          For instance, one may swap the leftmost 0 with 1.

//          For n = 11000, the output should be
//          increaseNumberRoundness(n) = false.
//          Roundness of n is 3, and there is no way to increase it.

namespace IncreaseNumberRoundness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(increaseNumberRoundness(902200100));
            Console.ReadKey();
        }

        // Returns whether it is possible to increase the roundness by swaping some pairs of digits
        static bool increaseNumberRoundness(int n)
        {
            bool isPossible = false;
            // Getting the first non-zero digit
            while (n % 10 == 0)
                n = n / 10;

            // getting the second non-zero
            while (n > 9)
            {
                if (n % 10 != 0)
                    n = n / 10;

                else
                {
                    isPossible = true;
                    break;
                }
            }

            return isPossible;

        }

    }
}
