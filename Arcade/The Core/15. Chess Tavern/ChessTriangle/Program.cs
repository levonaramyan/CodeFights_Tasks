using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Consider a bishop, a knight and a rook on an n × m chessboard. They are said to form a triangle
// if each piece attacks exactly one other piece and is attacked by exactly one piece.
// Calculate the number of ways to choose positions of the pieces to form a triangle.
// Note that the bishop attacks pieces sharing the common diagonal with it; the rook attacks
// in horizontal and vertical directions; and, finally, the knight attacks squares which are
// two squares horizontally and one square vertically, or two squares vertically
// and one square horizontally away from its position.
// https://codefightsuserpics.s3.amazonaws.com/tasks/chessTriangle/img/moves.png?_tm=1490625690642
// Example:
//          For n = 2 and m = 3, the output should be
//          chessTriangle(n, m) = 8.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/chessTriangle/img/combinations.png?_tm=1490625690826

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
