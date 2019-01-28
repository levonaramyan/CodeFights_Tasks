using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In ChessLand there is a small but proud chess bishop with a recurring dream.
// In the dream the bishop finds itself on an n × m chessboard with mirrors along each edge,
// and it is not a bishop but a ray of light. This ray of light moves only along diagonals
// (the bishop can't imagine any other types of moves even in its dreams), it never stops,
// and once it reaches an edge or a corner of the chessboard it reflects from it and moves on.
// Given the initial position and the direction of the ray, find its position
// after k steps where a step means either moving from one cell to the neighboring one
// or reflecting from a corner of the board.
// Example:
//          For boardSize = [3, 7], initPosition = [1, 2],
//          initDirection = [-1, 1], and k = 13, the output should be
//          chessBishopDream(boardSize, initPosition, initDirection, k) = [0, 1].
//          Here is the bishop's path:
//          [1, 2] -> [0, 3] -(reflection from the top edge)-> [0, 4] -> 
//          [1, 5] -> [2, 6] -(reflection from the bottom right corner)-> [2, 6] ->
//          [1, 5] -> [0, 4] -(reflection from the top edge)-> [0, 3] ->
//          [1, 2] -> [2, 1] -(reflection from the bottom edge)-> [2, 0] -(reflection from the left edge)->
//          [1, 0] -> [0, 1]
//          https://codefightsuserpics.s3.amazonaws.com/tasks/chessBishopDream/img/example.png?_tm=1530791315311

namespace ChessBishopDream
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] chessBishopDream(int[] boardSize, int[] initPosition, int[] initDirection, int k)
        {
            int[] pos = new int[2];
            for (int i = 0; i <= 1; i++)
                pos[i] = StepsDir(initPosition[i], initDirection[i], boardSize[i], k);

            return pos;
        }

        static int StepsDir(int p, int d, int l, int k)
        {
            int r = k / l;

            if (r % 2 == 1)
            {
                p = l - 1 - p;
                d = -d;
            }

            for (int i = 1; i <= k - r * l; i++)
            {
                if ((d < 0 && p == 0) || (d > 0 && p == l - 1)) d = -d;
                else p += d;
            }

            return p;
        }

    }
}
