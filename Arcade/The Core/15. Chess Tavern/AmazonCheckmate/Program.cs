using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// An amazon (also known as a queen+knight compound) is an imaginary chess piece that can move
// like a queen or a knight (or, equivalently, like a rook, bishop, or knight).
// The diagram below shows all squares which the amazon attacks from e4 
// circles represent knight-like moves while crosses correspond to queen-like moves).
// https://codefightsuserpics.s3.amazonaws.com/tasks/amazonCheckmate/img/amazon.png?_tm=1490625459392
// Recently you've come across a diagram with only three pieces left on the board:
// a white amazon, white king and black king. It's black's move. You don't have time
// to determine whether the game is over or not, but you'd like to figure it out in your head.
// Unfortunately, the diagram is smudged and you can't see the position of the black's king,
// so it looks like you'll have to check them all.
// Given the positions of white pieces on a standard chessboard, determine
// the number of possible black king's positions such that:
//      it's checkmate (i.e. black's king is under amazon's attack and it cannot make a valid move);
//      it's check (i.e. black's king is under amazon's attack but it can reach a safe square in one move);
//      it's stalemate (i.e. black's king is on a safe square but it cannot make a valid move);
//      black's king is on a safe square and it can make a valid move.
// Note that two kings cannot be placed on two adjacent squares(including two diagonally adjacent ones).
// Example:
//          For king = "d3" and amazon = "e4", the output should be
//          amazonCheckmate(king, amazon) = [5, 21, 0, 29].
//          https://codefightsuserpics.s3.amazonaws.com/tasks/amazonCheckmate/img/example1.png?_tm=1490625459585
//          Red crosses correspond to the checkmate positions, orange pluses refer to checks
//          and green circles denote safe squares.
//
//          For king = "a1" and amazon = "g5", the output should be
//          amazonCheckmate(king, amazon) = [0, 29, 1, 29].
//          https://codefightsuserpics.s3.amazonaws.com/tasks/amazonCheckmate/img/example2.png?_tm=1490625459719
//          Stalemate position is marked by a blue square.

namespace AmazonCheckmate
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] amazonCheckmate(string king, string amazon)
        {
            int[] res = new int[4];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string black = $"{(char)('a' + i)}{j + 1}";
                    if (black != amazon && !kingBeat(king, black))
                    {
                        int moves = 0;
                        for (int k = -1; moves == 0 && k <= 1; k++)
                            for (int h = -1; moves == 0 && h <= 1; h++)
                            {
                                string newPos = $"{(char)('a' + i + k)}{j + h + 1}";
                                moves = (newPos != black && onBoard(newPos) &&
                                         !amazonBeat(amazon, newPos, king) && !kingBeat(king, newPos)) ? 1 : 0;
                            }
                        res[0] += (amazonBeat(amazon, black, king) && moves == 0) ? 1 : 0;
                        res[1] += (amazonBeat(amazon, black, king) && moves == 1) ? 1 : 0;
                        res[2] += (!amazonBeat(amazon, black, king) && moves == 0) ? 1 : 0;
                        res[3] += (!amazonBeat(amazon, black, king) && moves == 1) ? 1 : 0;
                    }
                }
            }

            return res;
        }

        static bool amazonBeat(string a, string k, string whiteKing)
        {
            if (InBetween(a, whiteKing, k) || k == a) return false;
            int d1 = Math.Abs((int)a[0] - (int)k[0]);
            int d2 = Math.Abs((int)a[1] - (int)k[1]);
            if (d1 < 3 && d2 < 3) return true;
            if (d1 == 0 || d2 == 0) return true;
            if (d1 == d2) return true;
            return false;
        }

        static bool kingBeat(string k, string k1)
        {
            int d1 = Math.Abs((int)k[0] - (int)k1[0]);
            int d2 = Math.Abs((int)k[1] - (int)k1[1]);
            if (d1 < 2 && d2 < 2) return true;
            return false;
        }

        static bool onBoard(string p)
        {
            return (p[0] >= 'a' && p[0] <= 'h' && p[1] < '9' && p[1] > '0');
        }

        static bool InBetween(string a, string k, string k1)
        {
            bool isInBetween = false;
            bool kInDir = false;
            bool k1InDir = false;
            int s1 = (k[0] - a[0] != 0) ? Math.Sign(k[0] - a[0]) : 0;
            int s2 = (k[1] - a[1] != 0) ? Math.Sign(k[1] - a[1]) : 0;
            for (int i = 0; !k1InDir && i <= 8; i++)
            {
                k1InDir = (a[0] + i * s1 == k1[0]) && ((a[1] + i * s2 == k1[1])) ? true : k1InDir;
                kInDir = (a[0] + i * s1 == k[0]) && ((a[1] + i * s2 == k[1])) ? true : kInDir;
            }


            return k1InDir && kInDir;
        }

    }
}
