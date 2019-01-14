using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StolenLunch
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string stolenLunch(string note)
        {
            string res = "";
            char newChar = ' ';
            foreach (char i in note)
            {
                if (char.IsDigit(i)) newChar = (char)('a' + int.Parse($"{i}"));
                else if (char.IsLetter(i) && i <= 'j' && i >= 'a') newChar = (char)('0' + i - 'a');
                else newChar = i;
                res += newChar;
            }

            return res;

        }
    }
}
