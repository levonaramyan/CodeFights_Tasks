using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a rectangular matrix and integers a and b, consider the union of the ath row
// and the bth (both 0-based) column of the matrix (i.e. all cells that belong either
// to the ath row or to the bth column, or to both). Return sum of all elements of that union.
// Example:
//          For
//          matrix = [[1, 1, 1, 1], 
//                    [2, 2, 2, 2], 
//                    [3, 3, 3, 3]]
//          a = 1, and b = 3, the output should be
//          crossingSum(matrix, a, b) = 12.
//          Here(2 + 2 + 2 + 2) + (1 + 3) = 12.

namespace CrossingSum
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int crossingSum(int[][] matrix, int a, int b)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            int sum = -matrix[a][b];
            for (int i = 0; i < x; i++)
                sum += matrix[i][b];
            for (int i = 0; i < y; i++)
                sum += matrix[a][i];
            return sum;

        }
    }
}
