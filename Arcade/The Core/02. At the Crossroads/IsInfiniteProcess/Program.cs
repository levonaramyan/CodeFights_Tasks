using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given integers a and b, determine whether the following pseudocode results in an infinite loop

// while a is not equal to b do
//       increase a by 1
//       decrease b by 1
// Assume that the program is executed on a virtual machine which can store arbitrary long numbers and execute forever.

namespace IsInfiniteProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isInfiniteProcess(4,26));
            Console.ReadKey();
        }

        // Returns true if it is an infinite process
        static bool isInfiniteProcess(int a, int b)
        {
            return !(a <= b && (a - b) % 2 == 0);
        }
    }
}
