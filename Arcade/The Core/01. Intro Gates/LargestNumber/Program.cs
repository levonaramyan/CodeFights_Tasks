using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an integer n, return the largest number that contains exactly n digits.

// Example: For n = 2, the output should be: largestNumber(n) = 99.

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(largestNumber(3));
            Console.ReadKey();
        }

        // The method returns the biggest integer which contains n digits
        static int largestNumber(int n)
        {
            int a = 0;
            for (int i = 0; i < n; i++)
                a += 9 * (int)(Math.Pow(10, i));
            return a;
        }
    }
}
