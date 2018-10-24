using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given integers n, l and r, find the number of ways to represent n as a sum
// of two integers A and B such that l ≤ A ≤ B ≤ r.

// Example:
//          For n = 6, l = 2, and r = 4, the output should be
//          countSumOfTwoRepresentations2(n, l, r) = 2.
//          There are just two ways to write 6 as A + B, where 2 ≤ A ≤ B ≤ 4: 6 = 2 + 4 and 6 = 3 + 3.

namespace CountSumOfTwoRepresentations2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(countSumOfTwoRepresentations2(6,2,4));
            Console.ReadKey();
        }

        // Returns the number of possible n = A + B representations, l <= A <= B <= r.
        static int countSumOfTwoRepresentations2(int n, int l, int r)
        {
            int sum = 0;
            if (n <= 2 * r && n >= 2 * l)
                for (int i = l; i <= n - l && i <= n / 2; i++)
                {
                    int dif = n - i;
                    if (dif >= l && dif <= r) sum++;
                }

            return sum;

        }
    }
}
