using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In order to stop the Mad Coder evil genius you need to decipher the encrypted message he sent to his minions.
// The message contains several numbers that, when typed into a supercomputer, will launch a missile into the
// sky blocking out the sun, and making all the people on Earth grumpy and sad.

// You figured out that some numbers have a modified single digit in their binary representation.
// More specifically, in the given number n the kth bit from the right was initially set to 0,
// but its current value might be different.It's now up to you to write a function
// that will change the kth bit of n back to 0.

// Example:
//          For n = 37 and k = 3, the output should be
//          killKthBit(n, k) = 33.
//          3710 = 1001012 ~> 1000012 = 3310.

//          For n = 37 and k = 4, the output should be
//          killKthBit(n, k) = 37.

namespace KillKthBit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(killKthBit(37,6));
            Console.ReadKey();
        }

        // returns a new int, where the k-th bit is turned to 0
        static int killKthBit(int n, int k)
        {
            return n & ~(1 << (k - 1));
        }
    }
}
