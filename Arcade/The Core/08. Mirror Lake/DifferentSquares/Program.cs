using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a rectangular matrix containing only digits, calculate the number of different 2 × 2 squares in it.
// Example
//          For
//          matrix = [[1, 2, 1],
//                    [2, 2, 2],
//                    [2, 2, 2],
//                    [1, 2, 3],
//                    [2, 2, 1]]
//          the output should be
//          differentSquares(matrix) = 6.
//          Here are all 6 different 2 × 2 squares:
//          1 2
//          2 2
//
//          2 1
//          2 2
//
//          2 2
//          2 2
//
//          2 2
//          1 2
//
//          2 2
//          2 3
//
//          2 3
//          2 1

namespace DifferentSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[][] test = new int[5][];
            test[0] = new int[] { 1, 2, 1 };
            test[1] = new int[] { 2, 2, 2 };
            test[2] = new int[] { 2, 2, 2 };
            test[3] = new int[] { 1, 2, 3 };
            test[4] = new int[] { 2, 2, 1 };
            Console.WriteLine(differentSquares(test));
            Console.ReadKey();
        }

        static int differentSquares(int[][] matrix)
        {
            int difMatNum = 0; // The number of duplicating submatrixes

            // Mtrix, which indicates whether the element is new (0), or has a duplicate before it (1) 
            int y = matrix[0].Length;
            int x = matrix.Length;
            int[][] eqMatrix = new int[x - 1][];
            for (int i = 0; i < x - 1; i++)
            {
                eqMatrix[i] = new int[y - 1];
            }

            // If any two 2x2 elements in matrix are equal, then mark with 1 the position of the repeating element
            // For each [i,j] element, look only the elements which comes after it, i.e.
            // [i,j+1],[i,j+2],....,[i+1][0],....,[x-1,y-1]
            for (int i = 0; i < x - 1; i++)
            {
                for (int j = 0; j < y - 1; j++)
                {
                    for (int k = i; k < x - 1; k++)
                    {
                        for (int h = 0; h < y - 1; h++)
                        {
                            if (!(i == k && j == h) && !(i == k && h <= j))
                            {
                                if (twoDimmEquality(matrix, i, j, k, h) == 1)
                                {
                                    eqMatrix[k][h] = 1;
                                }
                            }
                        }
                    }
                }
            }

            // Calculating the number of duplicates
            for (int i = 0; i < x - 1; i++)
            {
                for (int j = 0; j < y - 1; j++)
                {
                    if (eqMatrix[i][j] == 1) difMatNum++;
                }
            }

            return ((x - 1) * (y - 1) - difMatNum);
        }

        // Returns 1, if 2x2 submatrixes with [i,j] and [k,h] indexes are equal, else returns 0.
        static int twoDimmEquality(int[][] matrix, int i, int j, int k, int h)
        {
            int areEqual = 0;
            for (int m = 0; m <= 1; m++)
            {
                for (int n = 0; n <= 1; n++)
                {
                    if (matrix[i + m][j + n] == matrix[k + m][h + n])
                        areEqual++;
                }
            }

            return areEqual == 4 ? 1 : 0;
        }
    }
}
