using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a matrix (i.e. an array of arrays), find its submatrix
// obtained by deleting the specified rows and columns.

namespace constructSubmatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing test matrix and the rows/cols to delete
            int[][] test = new int[3][];
            test[0] = new int[] {1,2,3,4 };
            test[1] = new int[] {4,5,6,7 };
            test[2] = new int[] {8,9,10,11 };
            int[] rowsDel = new int[] { 0};
            int[] colsDel = new int[] { 0};

            // applying the method and printing the result of the test
            int[][] subM = ConstructSubmatrix(test, rowsDel, colsDel);
            foreach (int[] i in subM)
            {
                foreach (int j in i) Console.Write($"{j} ");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // The method returns a new matrix, where the given rows and columns are deleted
        static int[][] ConstructSubmatrix(int[][] matrix, int[] rowsToDelete, int[] columnsToDelete)
        {
            // Initializing variables and parameters
            int xMatr = matrix.Length;
            int yMatr = matrix[0].Length;
            int xSub = xMatr - rowsToDelete.Length;
            int ySub = yMatr - columnsToDelete.Length;
            int indexX = 0;
            int indexY = 0;

            // initializing and constructing a new submatrix without given rows and cols
            int[][] subMatrix = new int[xSub][];
            for (int i = 0; i < xSub; i++)
            {
                indexY = 0;

                for (int r = 0; r < rowsToDelete.Length; r++)
                {
                    if (indexX == rowsToDelete[r]) indexX++;
                }

                subMatrix[i] = new int[ySub];
                for (int j = 0; j < ySub; j++)
                {
                    for (int c = 0; c < columnsToDelete.Length; c++)
                    {
                        if (indexY == columnsToDelete[c]) indexY++;
                    }

                    subMatrix[i][j] = matrix[indexX][indexY];
                    indexY++;
                }

                indexX++;
            }

            // Returning the resulting submatrix
            return subMatrix;            
        }
    }
}
