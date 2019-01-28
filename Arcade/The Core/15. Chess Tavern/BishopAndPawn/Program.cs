using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopAndPawn
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool bishopAndPawn(string bishop, string pawn)
        {
            int xBish = bishop[0] - 'a' + 1;
            int yBish = Convert.ToInt32($"{bishop[1]}");
            int xPawn = pawn[0] - 'a' + 1;
            int yPawn = Convert.ToInt32($"{pawn[1]}");

            return (Math.Abs(xBish - xPawn) == Math.Abs(yBish - yPawn));
        }
    }
}
