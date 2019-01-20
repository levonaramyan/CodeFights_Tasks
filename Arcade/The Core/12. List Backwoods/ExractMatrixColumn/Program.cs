using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a rectangular matrix and an integer column, return an array containing the elements
// of the columnth column of the given matrix (the leftmost column is the 0th one).
// Example:
//          For
//          matrix = [[1, 1, 1, 2], 
//                    [0, 5, 0, 4], 
//                    [2, 1, 3, 6]]
//          and column = 2, the output should be
//          extractMatrixColumn(matrix, column) = [1, 0, 3].

namespace ExractMatrixColumn
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] extractMatrixColumn(int[][] matrix, int column)
        {
            int[] a = new int[matrix.Length];
            for (int i = 0; i < a.Length; i++)
                a[i] = matrix[i][column];
            return a;

        }
    }
}
