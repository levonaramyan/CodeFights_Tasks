using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a character, check if it represents an odd digit, an even digit or not a digit at all.
// Example:
//          For symbol = '5', the output should be
//          characterParity(symbol) = "odd";
//
//          For symbol = '8', the output should be
//          characterParity(symbol) = "even";
//
//          For symbol = 'q', the output should be
//          characterParity(symbol) = "not a digit".

namespace CharacterParity
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string characterParity(char symbol)
        {
            return (!char.IsDigit(symbol)) ? "not a digit" : ((symbol % 2 == 0) ? "even" : "odd");

        }
    }
}
