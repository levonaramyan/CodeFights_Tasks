using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
