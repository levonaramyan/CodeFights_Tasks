using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Find the number of ways to express n as sum of some (at least two) consecutive positive integers.
// Example:
//          For n = 9, the output should be
//          isSumOfConsecutive2(n) = 2.
//          There are two ways to represent n = 9: 2 + 3 + 4 = 9 and 4 + 5 = 9.

//          For n = 8, the output should be
//          isSumOfConsecutive2(n) = 0.
//          There are no ways to represent n = 8.

namespace IsSumOfConsecutive2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isSumOfConsecutive2(9));
            Console.ReadKey();
        }

        // Returns a number of ways to represent n with a sum of two or more consec. numbers
        static int isSumOfConsecutive2(int n)
        {
            int numOfWays = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                int tempSum = i;
                int j = i;
                while (tempSum < n)
                {
                    j++;
                    tempSum += j;
                    if (tempSum == n) numOfWays++;
                }
            }

            return numOfWays;
        }
    }
}
