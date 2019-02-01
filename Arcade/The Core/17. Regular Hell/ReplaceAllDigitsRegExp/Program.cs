using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
// Implement a function that replaces each digit in the given string with a '#' character.
// Example:
//          For input = "There are 12 points", the output should be
//          replaceAllDigitsRegExp(input) = "There are ## points".

namespace ReplaceAllDigitsRegExp
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string replaceAllDigitsRegExp(string input)
        {
            return Regex.Replace(input, @"\d", "#");
        }
    }
}
