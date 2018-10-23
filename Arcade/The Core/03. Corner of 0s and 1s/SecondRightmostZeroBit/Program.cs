using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// Presented with the integer n, find the 0-based position of the second rightmost zero bit
// in its binary representation(it is guaranteed that such a bit exists), counting from right to left.

// Return the value of 2position_of_the_found_bit.
// Example:
//          For n = 37, the output should be
//          secondRightmostZeroBit(n) = 8.

//          37 = 100101. The second rightmost zero bit is at position 3 (0-based) from the right
//          in the binary representation of n. Thus, the answer is 23 = 8.

namespace SecondRightmostZeroBit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(secondRightmostZeroBit(37));
            Console.ReadKey();
        }

        // Returns the value of the position of second rightmost 0 bit
        static int secondRightmostZeroBit(int n)
        {
            return ((n | (n + 1)) ^ ((n | (n + 1)) + 1)) & ((n | (n + 1)) + 1);
        }
    }
}
