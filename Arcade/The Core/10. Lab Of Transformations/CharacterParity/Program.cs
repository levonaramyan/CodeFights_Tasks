using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
