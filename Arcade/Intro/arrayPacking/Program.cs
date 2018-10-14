using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given an array of up to four non-negative integers, each less than 256.
// PROBLEM: Your task is to pack these integers into one number M in the following way:
//          The first element of the array occupies the first 8 bits of M;
//          The second element occupies next 8 bits, and so on.
//          Return the obtained integer M.

// Note: the phrase "first bits of M" refers to the least significant bits of M - the right-most bits
// of an integer.For further clarification see the following example.

// Example
// For a = [24, 85, 0], the output should be arrayPacking(a) = 21784.
// An array[24, 85, 0] looks like[00011000, 01010101, 00000000] in binary.
// After packing these into one number we get 00000000 01010101 00011000
// (spaces are placed for convenience), which equals to 21784.

namespace arrayPacking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing, testing, printing
            int[] a = new int[] { 23, 45, 39 };
            Console.WriteLine(arrayPacking(a));
            Console.ReadKey();
        }

        // The method returns the packed array into one integer
        static int arrayPacking(int[] a)
        {
            int sum = 0; // will be the packed integer
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i] << (i * 8); // for each next item shift the binary code with 8 bits
            }

            return sum;

        }
    }
}
