using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.

// You're given an arbitrary 32-bit integer n. Take its binary representation, split bits
// into it in pairs (bit number 0 and 1, bit number 2 and 3, etc.) and swap bits in each pair.
// Then return the result as a decimal number.

// Example:
//          For n = 13, the output should be
//          swapAdjacentBits(n) = 14.
//          13 = 1101 ~> {11}{01} ~> 1110 = 14.

//          For n = 74, the output should be
//          swapAdjacentBits(n) = 133.
//          74 = 01001010 ~> {01}{00}{10}{10} ~> 10000101 = 133.

//          Note the preceding zero written in front of the initial number: since both numbers
//          are 32-bit integers, they have 32 bits in their binary representation.
//          The preceding zeros in other cases don't matter, so they are omitted.
//          Here, however, it does make a difference.

namespace SwapAdjacentBits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(swapAdjacentBits(13));
            Console.ReadKey();
        }

        // Returns a new integer, where the bits are formed from swaped ones of number n
        static int swapAdjacentBits(int n)
        {
            return ((n & 0x2AAAAAAA) >> 1) | ((n & 0x55555555) << 1);
        }
    }
}
