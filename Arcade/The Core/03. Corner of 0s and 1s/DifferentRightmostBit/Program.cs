using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're given two integers, n and m. Find position of the rightmost bit in which they differ
// in their binary representations (it is guaranteed that such a bit exists), counting from right to left.

// PROBLEM: Return the value of 2position_of_the_found_bit(0-based).

// Example:
//          For n = 11 and m = 13, the output should be
//          differentRightmostBit(n, m) = 2.
//          11 = 1011, 13 = 1101, the rightmost bit in which they differ is the bit
//          at position 1 (0-based) from the right in the binary representations. So the answer is 2^1 = 2.

namespace DifferentRightmostBit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(differentRightmostBit(11,13));
            Console.ReadKey();
        }

        // Returns the bit value of the righmost different bit in n and m.
        static int differentRightmostBit(int n, int m)
        {
            return (n ^ m) & -(n ^ m);
        }
    }
}
