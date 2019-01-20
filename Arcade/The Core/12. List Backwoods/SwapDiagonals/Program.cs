using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The longest diagonals of a square matrix are defined as follows:
// the first longest diagonal goes from the top left corner to the bottom right one;
// the second longest diagonal goes from the top right corner to the bottom left one.
// Given a square matrix, your task is to swap its longest diagonals by exchanging their elements
// at the corresponding positions.
// Example:
//          For
//          matrix = [[1, 2, 3],
//                    [4, 5, 6],
//                    [7, 8, 9]]
//          the output should be
//          swapDiagonals(matrix) = [[3, 2, 1],
//                                   [4, 5, 6],
//                                   [9, 8, 7]]

namespace SwapDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[][] swapDiagonals(int[][] matrix)
        {
            int len = matrix.Length;
            int[][] res = new int[len][];
            for (int i = 0; i < len; i++)
            {
                res[i] = new int[len];
                for (int j = 0; j < len; j++)
                    res[i][j] = matrix[i][j];
                res[i][i] = matrix[i][len - 1 - i];
                res[i][len - 1 - i] = matrix[i][i];
            }
            return res;

        }

    }
}
