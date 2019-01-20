using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The longest diagonals of a square matrix are defined as follows:
//      the first longest diagonal goes from the top left corner to the bottom right one;
//      the second longest diagonal goes from the top right corner to the bottom left one.
// Given a square matrix, your task is to reverse the order of elements on both of its longest diagonals.
// Example:
//          For
//          matrix = [[1, 2, 3],
//                    [4, 5, 6],
//                    [7, 8, 9]]
//          the output should be
//          reverseOnDiagonals(matrix) = [[9, 2, 7],
//                                        [4, 5, 6],
//                                        [3, 8, 1]]

namespace ReverseOnDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[][] reverseOnDiagonals(int[][] matrix)
        {
            int len = matrix.Length;
            int[][] res = new int[len][];
            for (int i = 0; i < len; i++)
            {
                res[i] = new int[len];
                for (int j = 0; j < len; j++)
                    res[i][j] = matrix[i][j];
            }

            for (int i = 0; i < len; i++)
            {
                res[i][i] = matrix[len - 1 - i][len - 1 - i];
                res[len - 1 - i][len - 1 - i] = matrix[i][i];
                res[i][len - 1 - i] = matrix[len - 1 - i][i];
                res[len - 1 - i][i] = matrix[i][len - 1 - i];
            }

            return res;
        }
    }
}
