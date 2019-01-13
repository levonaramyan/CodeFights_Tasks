using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a positive integer number and a certain length, we need to modify the given number
// to have a specified length. We are allowed to do that either by cutting out leading digits
// (if the number needs to be shortened) or by adding 0s in front of the original number.
// Example:
//          For number = 1234 and width = 2, the output should be
//          integerToStringOfFixedWidth(number, width) = "34";
//
//          For number = 1234 and width = 4, the output should be
//          integerToStringOfFixedWidth(number, width) = "1234";
//
//          For number = 1234 and width = 5, the output should be
//          integerToStringOfFixedWidth(number, width) = "01234".

namespace IntegerToStringOfFixedWidth
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string integerToStringOfFixedWidth(int number, int width)
        {
            return ($"{number}".Length >= width) ? $"{number}".Substring($"{number}".Length - width)
                : (new String('0', (width - $"{number}".Length)) + $"{number}");

        }
    }
}
