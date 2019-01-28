using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given the positions of a white bishop and a black pawn on the standard chess board,
// determine whether the bishop can capture the pawn in one move.
// The bishop has no restrictions in distance for each move, but is limited to diagonal movement.
// Check out the example below to see how it can move:
// https://codefightsuserpics.s3.amazonaws.com/tasks/bishopAndPawn/img/bishop.jpg?_tm=1530791225817
// Example:
//          For bishop = "a1" and pawn = "c3", the output should be
//          bishopAndPawn(bishop, pawn) = true.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/bishopAndPawn/img/ex1.jpg?_tm=1530791226122
//
//          For bishop = "h1" and pawn = "h3", the output should be
//          bishopAndPawn(bishop, pawn) = false.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/bishopAndPawn/img/ex2.jpg?_tm=1530791226426



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
