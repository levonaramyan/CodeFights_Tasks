using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a divisor and a bound, find the largest integer N such that:
// N is divisible by divisor.
// N is less than or equal to bound.
// N is greater than 0.
// It is guaranteed that such a number exists.

// Example:
//         For divisor = 3 and bound = 10, the output should be
//         maxMultiple(divisor, bound) = 9.
//         The largest integer divisible by 3 and not larger than 10 is 9.

namespace MaxMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(maxMultiple(3, 10));
            Console.ReadKey();
        }

        // Returns the largest integer divisible by divisor and not larger than bound.
        static int maxMultiple(int divisor, int bound)
        {
            int a = 0; // will be the maxMultiple-s return value

            // Checking the numbers by descending from bound.
            while (bound > 0)
            {
                if (bound % divisor == 0)
                {
                    a = bound;
                    break;
                }
                bound--;
            }

            return a;
        }
    }
}
