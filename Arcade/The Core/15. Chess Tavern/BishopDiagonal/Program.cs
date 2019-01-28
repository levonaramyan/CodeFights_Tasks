using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string[] bishopDiagonal(string bishop1, string bishop2)
        {
            int x1 = (int)bishop1[0] - (int)'a' + 1;
            int x2 = (int)bishop2[0] - (int)'a' + 1;
            int y1 = int.Parse($"{bishop1[1]}");
            int y2 = int.Parse($"{bishop2[1]}");

            if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
            {
                while (x1 > 1 && x1 < 8 && y1 > 1 && y1 < 8)
                {
                    x1 += Math.Sign(x1 - x2);
                    y1 += Math.Sign(y1 - y2);
                }

                while (x2 > 1 && x2 < 8 && y2 > 1 && y2 < 8)
                {
                    x2 -= Math.Sign(x1 - x2);
                    y2 -= Math.Sign(y1 - y2);
                }
            }
            string[] res = new string[] { $"{(char)(x1 + (int)'a' - 1)}{y1}", $"{(char)(x2 + (int)'a' - 1)}{y2}" };
            Array.Sort(res);

            return res;


        }

    }
}
