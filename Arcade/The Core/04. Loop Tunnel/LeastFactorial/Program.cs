using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an integer n, find the minimal k such that k = m! (where m! = 1 * 2 * ... * m) for some integer m; k >= n.
// In other words, find the smallest factorial which is not less than n.

// Example:
//          For n = 17, the output should be
//          leastFactorial(n) = 24.
//          17 < 24 = 4! = 1 * 2 * 3 * 4, while 3! = 1 * 2 * 3 = 6 < 17).

namespace LeastFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(leastFactorial(17));
            Console.ReadKey();
        }

        // Returns the smallest factorial which is not less tha n
        static int leastFactorial(int n)
        {
            int fact = 1;
            int k = 2;
            if (n > 1)
            {
                while (fact < n)
                {
                    fact *= k;
                    k++;
                }
            }

            return fact;

        }
    }
}
