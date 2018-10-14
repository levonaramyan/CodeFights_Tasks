using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Given a position of a knight on the standard chessboard,
//          find the number of different moves the knight can perform.

// The knight can move to a square that is two squares horizontally and one square vertically,
// or two squares vertically and one square horizontally away from it.The complete move therefore
// looks like the letter L.Check out the image below to see all valid moves for a knight piece
// that is placed on one of the central squares.

namespace chessKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and returning the result, number of possible steps
            Console.WriteLine(chessKnight("a1"));
            Console.ReadKey();
        }

        // Calculates the number of possible moves for the chess knight 
        static int chessKnight(string cell)
        {
            int x = cell[0] - 'a' + 1; // taking the coordinate x from string
            int y = Convert.ToInt32($"{cell[1]}"); // taking the y coordinate from string
            int count = 0; // will be the final count of possible moves

            // trying all of the possible (+/- 1 vs +/- 2) moves
            for (int i = 1; i <= 2; i++)
            {
                for (int l = -1; l <= 1; l = l + 2)
                {
                    for (int j = -1; j <= 1; j = j + 2)
                    {
                        int k = j * (3 - i); // (3 - i) is, i == 1? then 2, i==2? then 1
                        int h = i * l;
                        int newX = x + k;
                        int newY = y + h;

                        // if after the move it is still in the board then the move is possible
                        if (newX > 0 && newX < 9 && newY > 0 && newY < 9) count++;
                    }
                }

            }

            return count;
        }
    }
}
