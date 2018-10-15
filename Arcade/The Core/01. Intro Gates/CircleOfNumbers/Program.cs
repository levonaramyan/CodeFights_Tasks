using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Consider integer numbers from 0 to n - 1 written down along the circle in such a way that the distance
// between any two neighboring numbers is equal (note that 0 and n - 1 are neighboring, too).

// PROBLEM: Given n and firstNumber, find the number which is written in the radially opposite position to firstNumber.

// Example:
//         For n = 10 and firstNumber = 2, the output should be
//         circleOfNumbers(n, firstNumber) = 7.

namespace CircleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(circleOfNumbers(10, 2));
            Console.ReadKey();
        }

        // Returns the radially opposite number
        static int circleOfNumbers(int n, int firstNumber)
        {
            return (firstNumber + n / 2) % n;
        }
    }
}
