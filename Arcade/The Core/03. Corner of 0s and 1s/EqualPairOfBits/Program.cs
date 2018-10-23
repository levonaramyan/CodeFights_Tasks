using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're given two integers, n and m. Find position of the rightmost pair of equal bits
// in their binary representations (it is guaranteed that such a pair exists), counting from right to left.

// Return the value of 2position_of_the_found_pair(0-based).

// Example:
//          For n = 10 and m = 11, the output should be
//          equalPairOfBits(n, m) = 2.

//          10 = 1010, 11 = 1011, the position of the rightmost pair of equal bits
//          is the bit at position 1 (0-based) from the right in the binary representations.
//          So the answer is 2^1 = 2.

namespace EqualPairOfBits
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(equalPairOfBits(10,11));
            Console.ReadKey();
        }

        // Returns the value of a bit, which is equal in apair of bits in na and m
        static int equalPairOfBits(int n, int m)
        {
            return ~(n ^ m) & -~(n ^ m);
        }
    }
}
