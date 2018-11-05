using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagesNumberingWithInk
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int pagesNumberingWithInk(int current, int numberOfDigits)
        {
            numberOfDigits -= $"{current}".Length;
            while (numberOfDigits >= $"{current + 1}".Length)
            {
                current++;
                numberOfDigits -= $"{current}".Length;
            }

            return current;
        }

    }
}
