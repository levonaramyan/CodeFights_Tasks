using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The ticket number consists of even number of digits.
// The ticket is Lucky if the sum of digits in first half is equal to the one in second half
// PROBLEM: decide if the ticket with number n is lucky

namespace Challange1_isLucky
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isLucky(12345));
            Console.ReadKey();
        }

        // The method returns true if the ticket is lucky, and false, if not.
        static bool isLucky(int n)
        {
            string nStr = $"{n}";
            int nLen = nStr.Length;
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < nLen/2; i++)
            {
                sum1 += Convert.ToInt32(Convert.ToString(nStr[i]));
                sum2 += Convert.ToInt32(Convert.ToString(nStr[i+nLen/2]));
            }

            return sum1 == sum2;
        }
    }
}
