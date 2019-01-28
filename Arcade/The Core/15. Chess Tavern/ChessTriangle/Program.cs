using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int chessTriangle(int n, int m)
        {
            return CountHoriz(n, m) + CountHoriz(m, n);
        }

        static int CountHoriz(int n, int m)
        {
            return Math.Max(0, n - 1) * Math.Max(0, m - 2) * 8 +
                Math.Max(0, n - 2) * Math.Max(0, m - 2) * 8 +
                Math.Max(0, n - 1) * Math.Max(0, m - 3) * 8 +
                Math.Max(0, n - 2) * Math.Max(0, m - 3) * 8;
        }
    }
}
