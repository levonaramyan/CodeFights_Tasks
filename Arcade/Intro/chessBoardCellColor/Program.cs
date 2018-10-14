using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessBoardCellColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "A1";
            string b = "C3";
            Console.WriteLine(chessBoardCellColor(a, b));
            Console.ReadKey();
        }

        static bool chessBoardCellColor(string cell1, string cell2)
        {
            int let1Cell = cell1[0];
            int let2Cell = cell2[0];
            int num1Cell = cell1[1];
            int num2Cell = cell2[1];
            return ((let1Cell % 2 == let2Cell % 2) == (num1Cell % 2 == num2Cell % 2));
        }
    }
}
