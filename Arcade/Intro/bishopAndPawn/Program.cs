using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given the positions of a white bishop and a black pawn on the standard chess board,
// determine whether the bishop can capture the pawn in one move.
// The bishop has no restrictions in distance for each move, but is limited to diagonal movement.

namespace bishopAndPawn
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(bishopAndPawn("a1","c3"));
            Console.ReadKey();
        }

        // Returns whether the bishop can beat the pawn with just one step
        static bool bishopAndPawn(string bishop, string pawn)
        {
            // taking the number coordinates for both bishop and pawn
            int xBish = bishop[0] - 'a' + 1;
            int yBish = Convert.ToInt32($"{bishop[1]}");
            int xPawn = pawn[0] - 'a' + 1;
            int yPawn = Convert.ToInt32($"{pawn[1]}");

            // returns true if the absolute differences between x coordinates equals to y ones
            return (Math.Abs(xBish - xPawn) == Math.Abs(yBish - yPawn));
        }
    }
}
