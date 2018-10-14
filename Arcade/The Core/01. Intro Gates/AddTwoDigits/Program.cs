using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given a two-digit integer n. Return the sum of its digits.

// Example: For n = 29, the output should be: addTwoDigits(n) = 11.

namespace AddTwoDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(addTwoDigits(27));
            Console.ReadKey();
        }
        
        // The method returns a sum of digits in two digit number.
        static int addTwoDigits(int n)
        {
            return n % 10 + n / 10;
        }
    }
}
