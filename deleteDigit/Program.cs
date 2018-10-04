using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given some integer, find the maximal number you can obtain by deleting exactly one digit of the given number.

namespace deleteDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(deleteDigit(123156));
            Console.ReadKey();
        }

        // The method returns the biggest int, that can be ontained by deleting one digit of n
        static int deleteDigit(int n)
        {
            string nStr = $"{n}"; // converting n into string
            int length = nStr.Length; // calculating the length
            int max = Convert.ToInt32(nStr.Remove(length-1,1)); // taking initially the number without the last digit

            // iterating through the number by deleting the digits one by one
            for (int i = 0; i < length; i++)
            {
                string newN = nStr.Remove(i, length - i) + nStr.Substring(i + 1); // taking new shortened string
                int n2 = Convert.ToInt32(newN); // taking it as int
                max = n2 > max ? n2 : max; // taking the biggest
            }

            return max;
        }

    }
}
