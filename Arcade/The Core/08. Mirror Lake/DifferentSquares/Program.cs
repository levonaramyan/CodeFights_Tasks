using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentSquares
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int differentSquares(int[][] matrix)
        {
            int difMatNum = 0;

            int y = matrix[0].Length;
            int x = matrix.Length;
            int[][] eqMatrix = new int[x - 1][];
            for (int i = 0; i < x - 1; i++)
            {
                eqMatrix[i] = new int[y - 1];
            }

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

            for (int i = 0; i < x - 1; i++)
            {
                for (int j = 0; j < y - 1; j++)
                {
                    if (eqMatrix[i][j] == 1) difMatNum++;
                }
            }

            return ((x - 1) * (y - 1) - difMatNum);
        }

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
