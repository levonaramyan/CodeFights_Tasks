using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNumeralSystem
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] newNumeralSystem(char number)
        {
            int numDec = number - 'A';
            string[] res = new string[numDec / 2 + 1];
            for (int i = 0; i <= numDec / 2; i++)
            {
                res[i] = $"{(char)('A' + i)} + {(char)('A' + numDec - i)}";
            }

            return res;
        }
    }
}
