using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You're given three integers, a, b and c. It is guaranteed that two of these integers
// are equal to each other. What is the value of the third integer?

namespace ExtraNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(extraNumber(4,7,4));
            Console.ReadKey();
        }

        // Returns the number which is not equal to any of other two
        static int extraNumber(int a, int b, int c)
        {
            int other = a;
            if (other == b)
            {
                other = c;
            }
            else if (other == c)
            {
                other = b;
            }

            return other;
        }
    }
}
