using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Determine if the given number is a power of some non-negative integer.
// Example:
//          For n = 125, the output should be
//          isPower(n) = true;

//          For n = 72, the output should be
//          isPower(n) = false.

namespace IsPower
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the results
            Console.WriteLine(isPower(125));
            Console.ReadKey();
        }

        // Returns true if n is a square of an integer
        static bool isPower(int n)
        {
            bool res = false;
            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            {
                res = IsPowerOfm(n, i);
                if (res) break;
            }

            return n == 1 ? true : res;
        }

        static bool IsPowerOfm(int n, int m)
        {
            bool isPowerOfm = true;

            while (isPowerOfm && n > 1)
            {
                if (n % m > 0) isPowerOfm = false;
                n /= m;
            }

            return isPowerOfm;
        }

    }
}
