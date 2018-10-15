using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Some phone usage rate may be described as follows:
// first minute of a call costs min1 cents,
// each minute from the 2nd up to 10th(inclusive) costs min2_10 cents
// each minute after 10th costs min11 cents.

// PROBLEM: You have s cents on your account before the call. What is the duration
//          of the longest call (in minutes rounded down to the nearest integer) you can have?

// Example: For min1 = 3, min2_10 = 1, min11 = 2, and s = 20, the output should be
//          phoneCall(min1, min2_10, min11, s) = 14.

// Here's why:
// the first minute costs 3 cents, which leaves you with 20 - 3 = 17 cents;
// the total cost of minutes 2 through 10 is 1 * 9 = 9, so you can talk 9 more minutes and still have 17 - 9 = 8 cents;
// each next minute costs 2 cents, which means that you can talk 8 / 2 = 4 more minutes.
// Thus, the longest call you can make is 1 + 9 + 4 = 14 minutes long.

namespace PhoneCall
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(phoneCall(3,1,2,20));
            Console.ReadKey();
        }

        // Returns th total duration of a call
        static int phoneCall(int min1, int min2_10, int min11, int s)
        {
            int t1 = s / min1; // the total duration, if the cost was stable min1.
            int t2 = 0; // will be the duration of min2_10 tarriff
            int t3 = 0; // will be the duration of min11 tarriff

            // Iteraatively check, if the duration is > 1 min, > 10 min, and getting the values for t1, t2 and t3.
            if (t1 > 1)
            {
                t1 = 1;
                t2 = (s - min1) / min2_10;
                if (t2 > 9)
                {
                    t2 = 9;
                    t3 = (s - min1 - t2 * min2_10) / min11;
                }
            }

            return t1 + t2 + t3; // returning the total duration of three different tarriffs.
        }
    }
}
