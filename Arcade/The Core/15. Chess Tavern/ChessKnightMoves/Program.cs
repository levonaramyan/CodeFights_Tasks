using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a position of a knight on the standard chessboard,
// find the number of different moves the knight can perform.
// The knight can move to a square that is two squares horizontally and one square vertically,
// or two squares vertically and one square horizontally away from it.
// The complete move therefore looks like the letter L.Check out the image below to see
// all valid moves for a knight piece that is placed on one of the central squares.
// https://codefightsuserpics.s3.amazonaws.com/tasks/chessKnightMoves/img/knight.jpg?_tm=1530791323411
// Example:
//          For cell = "a1", the output should be
//          chessKnightMoves(cell) = 2.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/chessKnightMoves/img/ex_1.jpg?_tm=1530791323698
//
//          For cell = "c2", the output should be
//          chessKnightMoves(cell) = 6.
//          https://codefightsuserpics.s3.amazonaws.com/tasks/chessKnightMoves/img/ex_2.jpg?_tm=1530791324100

namespace ChessKnightMoves
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int chessKnightMoves(string cell)
        {
            int x = cell[0] - 'a' + 1;
            int y = Convert.ToInt32($"{cell[1]}");
            int count = 0;
            for (int i = 1; i <= 2; i++)
            {
                for (int l = -1; l <= 1; l = l + 2)
                {
                    for (int j = -1; j <= 1; j = j + 2)
                    {
                        int k = j * (3 - i);
                        int h = i * l;
                        int newX = x + k;
                        int newY = y + h;

                        if (newX > 0 && newX < 9 && newY > 0 && newY < 9) count++;
                    }
                }

            }

            return count;
        }
    }
}
