using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a rectangular matrix of integers, check if it is possible to rearrange its rows
// in such a way that all its columns become strictly increasing sequences (read from top to bottom).
// Example:
//          For
//          matrix = [[2, 7, 1], 
//                    [0, 2, 0], 
//                    [1, 3, 1]]
//          the output should be
//          rowsRearranging(matrix) = false;
//
//          For
//          matrix = [[6, 4],
//                    [2, 2],
//                    [4, 3]]
//          the output should be
//          rowsRearranging(matrix) = true.

namespace RowsRearranging
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool rowsRearranging(int[][] matrix)
        {
            bool isIncr = true;

            for (int i = 0; isIncr && i < matrix.Length - 1; i++)
                for (int k = i + 1; isIncr && k < matrix.Length; k++)
                {
                    isIncr = matrix[i][0] != matrix[k][0];
                    if (!isIncr) break;
                    bool more = matrix[i][0] > matrix[k][0];
                    for (int j = 1; isIncr && j < matrix[0].Length; j++)
                    {
                        isIncr = matrix[i][j] != matrix[k][j];
                        if (!isIncr) break;
                        if (matrix[i][j] > matrix[k][j] != more) isIncr = false;
                    }

                }

            return isIncr;
        }

    }
}
