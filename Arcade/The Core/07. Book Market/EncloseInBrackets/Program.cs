using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, enclose it in round brackets.
// Example:
//          For inputString = "abacaba", the output should be
//          encloseInBrackets(inputString) = "(abacaba)".

namespace EncloseInBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(encloseInBrackets("abds"));
            Console.ReadKey();
        }

        // Returns a new string, which contains an inputString in brackets
        static string encloseInBrackets(string inputString)
        {
            return $"({inputString})";
        }
    }
}
