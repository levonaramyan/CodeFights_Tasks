using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a rectangular matrix containing only digits, calculate the number of different 2 × 2 squares in it.

namespace differentSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test matrix
            int[][] test = new int[6][];
            test[0] = new int[] { 0, 9, 9, 9, 2 };
            test[1] = new int[] { 9, 9, 9, 9, 9 };
            test[2] = new int[] { 9, 9, 9, 9, 9 };
            test[3] = new int[] { 9, 9, 9, 9, 9 };
            test[4] = new int[] { 9, 9, 9, 9, 9 };
            test[5] = new int[] { 1, 9, 9, 9, 0 };

            // Testing and printing the result
            Console.WriteLine(differentSquares(test));
            Console.ReadKey();
        }

        // The method returns the number of different 2x2 matrixes
        static int differentSquares(int[][] matrix)
        {
            int difMatNum = 0; // The number of matrixes that are copies of others

            int y = matrix[0].Length;
            int x = matrix.Length;

            // Creating a new matrix with x-1 and y-1 dimensions.
            // It will store an information, whether current matrix is a new one, or a copy of another
            int[][] eqMatrix = new int[x-1][];
            for (int i = 0; i < x-1; i++)
            {
                eqMatrix[i] = new int[y - 1];
            }

            // for each i and j, continue looking for a copies, by continuing from index:
            // [i][j+1], [i][j+2]...[i+1][0],[i+1][1]....
            for (int i = 0; i < x - 1; i++)
            {
                for (int j = 0; j < y - 1; j++)
                {
                    for (int k = i; k < x-1; k++)
                    {
                        for (int h = 0; h < y-1; h++)
                        {
                            if (!(i==k && h<=j))
                            {
                                if (twoDimmEquality(matrix, i, j, k, h) == 1)
                                {
                                    eqMatrix[k][h] = 1; // 1, if [k][h] is a copy of [i][j] 2x2 matrix
                                }
                            }                            
                        }
                    }


                }
            }

            // calculating of copy matrixes
            for (int i = 0; i < x-1; i++)
            {
                for (int j = 0; j < y-1; j++)
                {
                    if (eqMatrix[i][j] == 1) difMatNum++;
                }
            }

            return ((x-1)*(y-1)- difMatNum); // returning the number of different matrixes  
        }

        // The method is getting coordinates of 2 2x2 matrixes in matrix[][], and return 1, if they are duplicates
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

            return areEqual == 4 ? 1:0;
        }
    }
}
