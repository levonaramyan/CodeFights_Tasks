using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// We want to turn the given integer into a number that has only one non-zero digit using a tail rounding approach.
// This means that at each step we take the last non 0 digit of the number and round it to 0 or to 10.
// If it's less than 5 we round it to 0 if it's larger than or equal to 5 we round it to 10
// (rounding to 10 means increasing the next significant digit by 1). The process stops immediately once there
// is only one non-zero digit left.

// Example
//          For n = 15, the output should be
//          rounders(n) = 20;

//          For n = 1234, the output should be
//          rounders(n) = 1000.
//          1234 -> 1230 -> 1200 -> 1000.

//          For n = 1445, the output should be
//          rounders(n) = 2000.
//          1445 -> 1450 -> 1500 -> 2000.

namespace Rounders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(rounders(15));
            Console.ReadKey();
        }

        // Returns the rounded number
        static int rounders(int n)
        {
            int nTemp = n;
            int divider = 1;

            // Digit by digit round and pass the 1-s, if there are
            while (nTemp / 10 != 0)
            {
                int adding = 0;
                if ((n / divider) % 10 >= 5) adding = 1;

                divider *= 10;
                n = (n / divider + adding) * divider;
                nTemp /= 10;
            }
            return n;

        }
    }
}
