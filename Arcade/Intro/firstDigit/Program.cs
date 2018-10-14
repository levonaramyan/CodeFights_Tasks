using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Find the leftmost digit that occurs in a given string.

namespace firstDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(firstDigit("blabla5jkhjkh"));
            Console.ReadKey();
        }

        // finding the first occuring digit in inputString
        static char firstDigit(string inputString)
        {
            char digit = 'a';
            foreach (char i in inputString)
            {
                String elem = Convert.ToString(i);
                int elemNum;
                bool isDigit = int.TryParse(elem, out elemNum);
                digit = i;
                if (isDigit) break;            
            }

            return digit;
        }
    }
}
